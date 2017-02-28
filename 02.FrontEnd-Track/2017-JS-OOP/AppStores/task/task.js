function solve() {
	// Your classes
	function validatorForStringLength(value, upperLimit) {
		if (value.length < 1 || value.length > upperLimit) {
			throw Error('Invalid name length!');
		}

		if (!value.match(/^[a-zA-Z0-9 ]/)) {
			throw Error('Invalid App name!');
		}
	}
	function validateIfValueIsString(value) {
		if (typeof value !== 'string') {
			throw Error('Invalid string!');
		}
	}
	function validateIfValueIsNumber(value) {
		if (typeof value !== 'number' || value <= 0) {
			throw Error('Version must be positive number!');
		}
	}
	function validateRatingIfInRange(value) {
		if (typeof value !== 'number' || value < 1 || value > 10) {
			throw Error('Rating must be number between 1 and 10!');
		}
	}

	function createApp(app) {
		return {
			name: app.name,
			description: app.description,
			version: app.version,
			rating: app.rating,
			apps: app.apps
		};
	}

	class App {
		constructor(name, description, version, rating) {
			validateIfValueIsString(name);
			validatorForStringLength(name, 24);
			validateIfValueIsString(description);
			validateIfValueIsNumber(version);
			validateRatingIfInRange(rating);

			this._name = name;
			this._description = description;
			this._version = version;
			this._rating = rating;
		}
		get name() {
			return this._name;
		}

		get description() {
			return this._description;
		}

		get version() {
			return this._version;
		}

		get rating() {
			return this._rating;
		}

		release(options) {
			if (typeof options !== 'object') {
				options = { version: options };
			}

			validateIfValueIsNumber(options.version);
			if (this._version >= options.version) {
				throw Error('Version must be newer!');
			}

			this._version = options.version;

			if (options.hasOwnProperty('description')) {
				validateIfValueIsString(options.description);
				this._description = options.description;
			}

			if (options.hasOwnProperty('rating')) {
				validateRatingIfInRange(options.rating);
				this._rating = options.rating;
			}

			return this;
		}
	}

	class Store extends App {
		constructor(name, description, version, rating) {
			super(name, description, version, rating);
			this._apps = [];
		}

		get apps() {
			return this._apps;
		}

		uploadApp(app) {
			if (!(app instanceof App)) {
				throw Error('app must be App object!');
			}

			let index = this._apps.findIndex(a => a.name === app.name);

			if (index >= 0) {
				this._apps.splice(index, 1);
			}

			this._apps.push(createApp(app));

			return this;
		}

		takedownApp(name) {
			let index = this._apps.findIndex(a => a.name === name);

			if (index < 0) {
				throw Error('App not found!');
			}

			this._apps.splice(index, 1);

			return this;
		}

		search(pattern) {
			pattern = pattern.toLowerCase();

			return (this._apps
				.filter(a => a.name.toLowerCase().indexOf(pattern) >= 0)
				.sort((x, y) => x.name.localeCompare(y.name)));
		}

		listMostRecentApps(count) {
			if (typeof count === 'undefined') {
				count = 10;
			}

			return this._apps.reverse().slice(0, count);
		}

		listMostPopularApps(count) {
			if (typeof count === 'undefined') {
				count = 10;
			}

			let sorted = this._apps.sort((x, y) => {
				if (x.name === y.name) {
					return x.time - y.time;
				}

				return x.name.localeCompare(y.name);
			});

			return this._apps.slice(0, count);
		}
	}

	class Device {
		constructor(hostname, apps) {
			validateIfValueIsString(hostname);
			validatorForStringLength(hostname, 32);

			if (!(Array.isArray(apps))) {
				throw Error('Invalid app collection!');
			}

			if (!apps.every(a => a instanceof App)) {
				throw Error('There is un Invalid app in the passed collection!');
			}

			this._hostname = hostname;
			this._apps = [];
			this._stores = apps.filter(x => x instanceof Store).map(x => createApp(x));
		}

		get hostname() {
			return this._hostname;
		}

		get apps() {
			return this._apps;
		}

		search(pattern) {
			pattern = pattern.toLowerCase();
			let result = {};

			this._stores.forEach(store => {
				store.apps.forEach(x => {
					if (x.name.toLowerCase().indexOf(pattern) < 0) {
						return;
					}

					if (result.hasOwnProperty(x.name) && x.version <= result[x.name].version) {
						return;
					}

					result[x.name] = x;
				});
			});

			return Object.keys(result).sort().map(key => result[key]);

		}
		install(name) {
			let bestApp = { version: -1 };

			this._stores.forEach(store => {
				let currApp = store.apps.find(a => a.name === name);

				if (currApp && bestApp.version < currApp.version) {
					bestApp = currApp;
				}

			});

			if (bestApp.version < 0) {
				throw Error('App not found!');
			}

			if (this._apps.every(a => a.name !== name)) {
				this._apps.push(createApp(bestApp));

				if (bestApp instanceof Store) {
					this._stores.push(createApp(bestApp));
				}
			}
			return this;
		}
		uninstall(name) {
			let index = this._apps.findIndex(a => a.name === name);

			if (index < 0) {
				throw Error('App not found!');
			}

			this._apps.splice(index, 1);

			index = this._stores.findIndex(s => s.name === name);

			if (index >= 0) {
				this._stores.splice(index, 1);
			}

			return this;
		}
		listInstalled() {
			return (this._apps.slice().sort((x, y) => x.name.localeCompare(y.name)));
		}
		update() {
			this._apps = this._apps.map(app => {
				const name = app.name;

				let bestApp = app;

				this._stores.forEach(store => {
					const currApp = store.apps.find(x => x.name === name);
					
					if (currApp && bestApp.version < currApp.version) {
						bestApp = currApp;
					}
				});

				return bestApp;
			});

			return this;
		}
	}

	return {
		createApp(name, description, version, rating) {
			// returns a new App object
			return new App(name, description, version, rating);
		},
		createStore(name, description, version, rating) {
			// returns a new Store object
			return new Store(name, description, version, rating);
		},
		createDevice(hostname, apps) {
			// returns a new Device object
			return new Device(hostname, apps);
		}
	};
}

// Submit the code above this line in bgcoder.com
module.exports = solve;