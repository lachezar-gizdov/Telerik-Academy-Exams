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
			if (typeof options === 'number' && options <= this.version) {
				throw Error('Older version!');
			}
			if (typeof options === 'number') {
				this.version = options;
			}

			if (typeof options === 'object') {
				if (options.hasOwnProperty('version')) {
					if (this.version < options.version && typeof options.version === 'number') {
						this.version = options.version;
						if (options.hasOwnProperty('description')) {
							if (typeof options.description === 'string') {
								this.description = options.description;
							}
							else {
								throw Error('Invalid Description!');
							}
						}
						if (options.hasOwnProperty('rating')) {
							if (typeof options.rating === 'number' && options.rating > 0 && options.rating <= 10) {
								this.rating = options.rating;
							}
							else {
								throw Error('Invalid rating!');
							}
						}
					} else {
						throw Error('Invalid new version!');
					}
				} else {
					throw Error('Invalid new version!');
				}
			}
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
		set apps(value) {
			this._apps = value;
		}
		uploadApp(app) {
			if (!(app instanceof App)) {
				throw Error('app must be App object!');
			}
			let index = this._apps.findIndex(a => a.name === app.name);
			if (index === -1) {
				this._apps.push(createApp(app));
				index = this._apps.findIndex(a => a.name === app.name);
			} else {
				if (this._apps[index].version < app.version) {
					this._apps[index].description = app.description;
					this._apps[index].rating = app.rating;
				}
				else {
					throw Error('App is already up to date!');
				}
			}
			return this;
		}
		takedownApp(app) {
			let index = this.apps.findIndex(a => a.name === app.name);
			if (index < 0) {
				throw Error('App not found!');
			}
			this.apps.splice(index, 0);
			return this;
		}
		search(pattern) {
			return this.apps
				.filter(a => a.name.includes(pattern.toLowerCase()))
				.sort((x, y) => x.name.toLowerCase().localeCompare(y.name.toLowerCase()));
		}
		listMostRecentApps(count) {
			if (typeof count === 'undefined') {
				count = 10;
			}
			return this.apps.slice(0, count - 1);
		}
		listMostPopularApps(count) {
			if (typeof count === 'undefined') {
				count = 10;
			}
			let sorted = this.apps.sort((x, y) => {
				if (x.name === y.name) {
					return x.time - y.time;
				}
				return x.name.localeCompare(y.name);
			});
			return this.apps.slice(0, count + 1);
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
		}
		get hostname() {
			return this._hostname;
		}
		get apps() {
			return this._apps;
		}
		search(pattern) {
			let stores = this.apps.filter(a => a instanceof Store),
				result = [],
				foundInCurrStore = [];
			stores.forEach(function (element) {
				foundInCurrStore = element
					.filter(a => a.name.includes(pattern.toLowerCase()))
					.sort((x, y) => x.name.toLowerCase()
						.localeCompare(y.name.toLowerCase()));
				result = [...result, ...foundInCurrStore];
			});
			return result;
		}
		install(name) {
			let stores = this.apps.filter(a => a instanceof Store),
				found = false,
				foundApp = {},
				ver = 0;
			stores.forEach(function (element) {
				var index = element.apps.findIndex(a => a.name === name) < 0;
				if (index >= 0) {
					found = true;
					if (ver <= element[index].ver) {
						foundApp = element[index];
						ver = element[index].ver;
					}
				}
			});
			if (!found) {
				throw Error('App with that name cannot be found in all stores!');
			}
			this.apps.push(foundApp);

			return this;
		}
		uninstall(name) {
			let index = this.apps.indexOf(a => a.name === name);
			if (index < 0) {
				throw Error('App not found!');
			}

			this.apps.splice(index, 1);
			return this;
		}
		listInstalled() {
			return this.apps.sort((x, y) => x.name.localeCompare(y.name));
		}
		update() {

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