function solve() {
	// Your classes

	let GetNextID = (function () {
		let id = 0;
		return function () {
			id += 1;
			return id;
		};
	}());

	class Product {
		constructor(manufacturer, model, price) {
			this._id = GetNextID();
			this.manufacturer = manufacturer;
			this.model = model;
			this.price = price;
		}

		get id() {
			return this._id;
		}
		get manufacturer() {
			return this._manufacturer;
		}
		set manufacturer(value) {
			if (typeof value !== 'string') {
				throw Error;
			}
			if (value.length < 1 || value.length > 20) {
				throw Error;
			}
			this._manufacturer = value;
		}
		get model() {
			return this._model;
		}
		set model(value) {
			if (typeof value !== 'string') {
				throw Error;
			}
			if (value.length < 1 || value.length > 20) {
				throw Error;
			}
			this._model = value;
		}
		get price() {
			return this._price;
		}
		set price(value) {
			if (typeof value !== 'number') {
				throw Error;
			}
			if (value <= 0) {
				throw Error;
			}
			this._price = value;
		}

		getLabel() {

		}
	}

	class SmartPhone extends Product {
		constructor(manufacturer, model, price, screenSize, operatingSystem) {
			super(manufacturer, model, price);
			this.screenSize = screenSize;
			this.operatingSystem = operatingSystem;
		}

		get screenSize() {
			return this._screenSize;
		}
		set screenSize(value) {
			if (typeof value !== 'number') {
				throw Error;
			}
			if (value <= 0) {
				throw Error;
			}
			this._screenSize = value;
		}
		get operatingSystem() {
			return this._operatingSystem;
		}
		set operatingSystem(value) {
			if (typeof value !== 'string') {
				throw Error;
			}
			if (value.length < 1 || value.length > 10) {
				throw Error;
			}
			this._operatingSystem = value;
		}
		get className() {
			return this._className;
		}

		getLabel() {
			let result = 'SmartPhone - ' + this.manufacturer + ' ' + this.model + ' - ' + '**' + this.price + '**';

			return result;
		}
	}

	class Charger extends Product {
		constructor(manufacturer, model, price, outputVoltage, outputCurrent) {
			super(manufacturer, model, price);
			this.outputVoltage = outputVoltage;
			this.outputCurrent = outputCurrent;
		}

		get outputVoltage() {
			return this._outputVoltage;
		}
		set outputVoltage(value) {
			if (typeof value !== 'number') {
				throw Error;
			}
			if (value < 5 || value > 20) {
				throw Error;
			}
			this._outputVoltage = value;
		}
		get outputCurrent() {
			return this._outputCurrent;
		}
		set outputCurrent(value) {
			if (typeof value !== 'number') {
				throw Error;
			}
			if (value < 100 || value > 3000) {
				throw Error;
			}
			this._outputCurrent = value;
		}
		getLabel() {
			let result = 'Charger - ' + this.manufacturer + ' ' + this.model + ' - ' + '**' + this.price + '**';

			return result;
		}
	}

	class Router extends Product {
		constructor(manufacturer, model, price, wifiRange, lanPorts) {
			super(manufacturer, model, price);
			this.wifiRange = wifiRange;
			this.lanPorts = lanPorts;
		}

		get wifiRange() {
			return this._wifiRange;
		}
		set wifiRange(value) {
			if (typeof value !== 'number') {
				throw Error;
			}
			if (value <= 0) {
				throw Error;
			}
			this._wifiRange = value;
		}
		get lanPorts() {
			return this._lanPorts;
		}
		set lanPorts(value) {
			if (typeof value !== 'number') {
				throw Error;
			}
			if (value <= 0 || value % 1 !== 0) {
				throw Error;
			}
			this._lanPorts = value;
		}
		getLabel() {
			let result = 'Router - ' + this.manufacturer + ' ' + this.model + ' - ' + '**' + this.price + '**';

			return result;
		}
	}

	class Headphones extends Product {
		constructor(manufacturer, model, price, quality, hasMicrophone) {
			super(manufacturer, model, price);
			this.quality = quality;
			this.hasMicrophone = hasMicrophone;
		}

		get quality() {
			return this._quality;
		}
		set quality(value) {
			if (typeof value !== 'string') {
				throw Error;
			}
			if (value !== 'high' && value !== 'mid' && value !== 'low') {
				throw Error;
			}
			this._quality = value;
		}
		get hasMicrophone() {
			return this._hasMicrophone;
		}
		set hasMicrophone(value) {
			if (value) {
				this._hasMicrophone = true;
			}

			this._hasMicrophone = false;
		}
		getLabel() {
			let result = 'Headphones - ' + this.manufacturer + ' ' + this.model + ' - ' + '**' + this.price + '**';

			return result;
		}
	}

	class HardwareStore {
		constructor(name) {
			this.name = name;
			this.products = [];
			this.soldProducts = [];
		}

		get name() {
			return this._name;
		}
		set name(value) {
			if (typeof value !== 'string') {
				throw Error;
			}
			if (value.length < 1 || value.length > 20) {
				throw Error;
			}
			this._name = value;
		}

		stock(product, quantity) {
			if (!(product instanceof Product)) {
				throw Error;
			}
			if (typeof quantity !== 'number') {
				throw Error;
			}
			if (quantity <= 0 || quantity % 1 !== 0) {
				throw Error;
			}
			for (let i = 0; i < quantity; i += 1) {
				this.products.push(product);
			}

			return this;
		}

		sell(productId, quantity) {
			if (quantity <= 0 || quantity % 1 !== 0) {
				throw Error;
			}
			let counter = 0;
			this.products.forEach(function (product) {
				if (product.id === productId) {
					counter += 1;
				}
			});
			if (counter < quantity) {
				throw Error;
			}
			for (let i = 0; i < quantity; i += 1) {
				let index = this.products.findIndex(p => p.id === productId);
				this.soldProducts.push(this.products[index]);
				this.products.splice(index, 1);
			}

			return this;
		}

		getSold() {
			return this.soldProducts.reduce((cost, product) => cost + product.price, 0);
		}

		search(options) {
			if (typeof options === 'string') {
				let pattern = options.toLocaleLowerCase();
				let flags = {};
				let uniques = this.products.filter(function (product) {
					if (flags[product.id]) {
						return false;
					}
					flags[product.id] = true;
					return true;
				});
				let counter = 0;

				return uniques
					.filter(p => p.manufacturer.toLocaleLowerCase().indexOf(pattern) >= 0
						|| p.model.toLocaleLowerCase().indexOf(pattern) >= 0).map(p => {
							counter = 0;
							this.products.forEach(function (product) {
								if (product.id === p.id) {
									counter += 1;
								}
							});
							return {
								product: p,
								quantity: counter
							};
						});
			}
			if (typeof options === 'object') {
				let flags = {};
				let uniques = this.products.filter(function (product) {
					if (flags[product.id]) {
						return false;
					}
					flags[product.id] = true;
					return true;
				});
				let counter = 0;

				if (options.hasOwnProperty('manufacturerPattern')) {
					uniques.filter(p => p.manufacturer.indexOf(options.manufacturerPattern) >= 0);
				}

				if (options.hasOwnProperty('modelPattern')) {
					uniques.filter(p => p.model.indexOf(options.modelPattern) >= 0);
				}

				if (options.hasOwnProperty('type')) {
					uniques.filter(p => p.constructor.name === options.type);
				}
				if (options.hasOwnProperty('minPrice')) {
					uniques.filter(p => p.price >= options.minPrice);
				}

				if (options.hasOwnProperty('maxPrice')) {
					uniques.filter(p => p.price <= options.maxPrice);
				}

				return uniques.map(p => {
					counter = 0;
					this.products.forEach(function (product) {
						if (product.id === p.id) {
							counter += 1;
						}
					});

					return {
						product: p,
						quantity: counter
					};
				});
			}

			throw Error;
		}

	}

	return {
		getSmartPhone(manufacturer, model, price, screenSize, operatingSystem) {
			// returns SmarhPhone instance
			return new SmartPhone(manufacturer, model, price, screenSize, operatingSystem);
		},
		getCharger(manufacturer, model, price, outputVoltage, outputCurrent) {
			// returns Charger instance
			return new Charger(manufacturer, model, price, outputVoltage, outputCurrent);
		},
		getRouter(manufacturer, model, price, wifiRange, lanPorts) {
			// returns Router instance
			return new Router(manufacturer, model, price, wifiRange, lanPorts);
		},
		getHeadphones(manufacturer, model, price, quality, hasMicrophone) {
			// returns Headphones instance
			return new Headphones(manufacturer, model, price, quality, hasMicrophone);
		},
		getHardwareStore(name) {
			// returns HardwareStore instance
			return new HardwareStore(name);
		}
	};
}

// Submit the code above this line in bgcoder.com
module.exports = solve; // DO NOT SUBMIT THIS LINE


const result = solve();
const phone = result.getSmartPhone('HTC', 'One', 903, 5, 'Android');
//console.log(phone.getLabel());
const headphones = result.getHeadphones('Sennheiser', 'PXC 550 Wireless', 340, 'high', false);
const store = result.getHardwareStore('Magazin');
store.stock(phone, 1).stock(headphones, 15);
console.log(store.search('sen'));
console.log(store.search({ type: 'SmartPhone', maxPrice: 1000 }));
//console.log(store.search({ type: 'SmartPhone', maxPrice: 900 }));
//store.sell(headphones.id, 2);
//console.log(store.getSold());