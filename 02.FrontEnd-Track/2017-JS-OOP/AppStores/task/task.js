function solve() {
	// Your classes
	let validatorForStringLength = function (value, upperLimit) {
		if (value.length < 1 || value.length > upperLimit) {
			throw Error('Invalid name length!');
		}
		if (value.match(!/[^a-zA-Z0-9 ]/)) {
			throw Error('Invalid App name!');
		}
	};
	let validateIfValueIsString = function (value) {
		if (typeof value !== 'string') {
			throw Error('Invalid string!');
		}
	};
	let timeUploaded = (function () {
		let time = 0;
		function nextUpload() {
			time += 1;
			return time;
		}
		return {
			nextUpload: nextUpload
		};
	})();
	class App {
		constructor(name, description, version, rating) {
			this.name = name;
			this.description = description;
			this.version = version;
			this.rating = rating;
			this.time = 0;
		}
		get time() {
			return this._time;
		}
		set time(value) {
			this._time = value;
		}
		get name() {
			return this._name;
		}
		set name(value) {
			validateIfValueIsString(value);
			validatorForStringLength(value, 24);
			this._name = value;
		}
		get description() {
			return this._description;
		}
		set description(value) {
			validateIfValueIsString(value);
			this._description = value;
		}
		get version() {
			return this._version;
		}
		set version(value) {
			if (typeof value !== 'number' || value < 1) {
				throw Error('Version must be positive number!');
			}
			this._version = value;
		}
		get rating() {
			return this._rating;
		}
		set rating(value) {
			if (typeof value !== 'number' || value < 1 || value > 10) {
				throw Error('Rating must be number between 1 and 10!');
			}
			this._rating = value;
		}
		release(options) {
			if (typeof options === 'number' && options <= this.version) {
				throw Error('Older version!');
			}
			if (typeof options === 'number') {
				this.version = options;
			}

			if (typeof options === 'object') {
				if (options.hasOwnProperty(version)) {
					if (this.version < options.version && typeof options.version === 'number') {
						this.version = options.version;
						if (options.hasOwnProperty(description)) {
							if (typeof options.description === 'string') {
								this.description = options.description;
							}
							else {
								throw Error('Invalid Description!');
							}
						}
						if (options.hasOwnProperty(rating)) {
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
			this.apps = [];
		}
		get apps() {
			return this._apps;
		}
		set apps(value) {
			this._apps = value;
		}
		uploadApp(app) {
			if (!(app instanceof App) || (app instanceof Store)) {
				throw Error('app must be App-like object!');
			}
			let index = this.apps.findIndex(a => a.name === app.name);
			if (index === -1) {
				this.apps.push(new App(app.name, app.description, app.version, app.description));
				index = this.apps.findIndex(a => a.name === app.name);
				this.apps[index].time = timeUploaded.nextUpload();
			} else {
				if (this.apps[index].version < app.version) {
					this.apps[index].description = app.description;
					this.apps[index].rating = app.rating;
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
			if (count === null || typeof count === 'undefined') {
				count = 10;
			}
			return this.apps.slice(0, count - 1);
		}
		listMostPopularApps(count) {
			if (count === null || typeof count === 'undefined') {
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
			this.hostname = hostname;
			this.apps = [];
		}
		get hostname() {
			return this._hostname;
		}
		set hostname(value) {
			validatorForStringLength(value, 32);
			validateIfValueIsString(value);
			this._hostname = value;
		}
		get apps() {
			return this._apps;
		}
		set apps(value) {
			if (!(Array.isArray(value))) {
				throw Error('Invalid app collection!');
			}
			value.forEach(function (element) {
				if (!((element instanceof App) || (element instanceof Store))) {
					throw Error('There is un Invalid app in the passed collection!');
				}
			});
			this._apps = value;
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