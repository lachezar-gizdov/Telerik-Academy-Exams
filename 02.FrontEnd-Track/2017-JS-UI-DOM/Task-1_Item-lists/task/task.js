function solve() {

	return function (selector, defaultLeft, defaultRight) {
		var element = document.querySelector(selector);
		defaultLeft = defaultLeft || [];
		defaultRight = defaultRight || [];

		var docFragment = document.createDocumentFragment();

		var columnContainer = document.createElement("div");
		columnContainer.className = "column-container";

		var leftColumn = document.createElement("div");
		leftColumn.className = "column";

		var rightColumn = document.createElement("div");
		rightColumn.className = "column";

		columnContainer.appendChild(leftColumn);
		columnContainer.appendChild(rightColumn);
		docFragment.appendChild(columnContainer);

		var leftSelect = document.createElement("div");
		leftSelect.className = "select";

		var rightSelect = document.createElement("div");
		rightSelect.className = "select";

		var leftLabel = document.createElement("label");
		leftLabel.setAttribute("for", "select-left-column");
		leftLabel.innerHTML = "Add here";

		var rightLabel = document.createElement("label");
		rightLabel.setAttribute("for", "select-right-column");
		rightLabel.innerHTML = "Add here";

		var leftRadioBtn = document.createElement("input");
		leftRadioBtn.setAttribute("type", "radio");
		leftRadioBtn.setAttribute("checked", "checked");
		leftRadioBtn.setAttribute("name", "column-select");
		leftRadioBtn.id = "select-left-column";
		leftSelect.appendChild(leftRadioBtn);
		leftSelect.appendChild(leftLabel);

		var rightRadioBtn = document.createElement("input");
		rightRadioBtn.setAttribute("type", "radio");
		rightRadioBtn.setAttribute("name", "column-select");
		rightRadioBtn.id = "select-right-column";
		rightSelect.appendChild(rightRadioBtn);
		rightSelect.appendChild(rightLabel);

		leftColumn.appendChild(leftSelect);
		rightColumn.appendChild(rightSelect);

		var leftOl = document.createElement("ol");

		var removeImg = document.createElement("img");
		removeImg.className = "delete";
		removeImg.setAttribute("src", "imgs/Remove-icon.png");

		defaultLeft.forEach(function (element) {
			var li = document.createElement("li");
			li.className = "entry";
			li.appendChild(removeImg.cloneNode(true));
			li.innerText = element;
			li.appendChild(removeImg.cloneNode(true));

			li.addEventListener("click", function (event) {
				var target = event.target;

				if (target.className === "delete") {
					target = target.parentNode;
					target.removeChild(event.target);
					inputField.value = target.innerHTML.trim();
					target.parentNode.removeChild(target);
				}
			});

			leftOl.appendChild(li);
		});

		leftColumn.appendChild(leftOl);

		var rightOl = document.createElement("ol");

		defaultRight.forEach(function (element) {
			var li = document.createElement("li");
			li.className = "entry";
			li.innerText = element;

			li.appendChild(removeImg.cloneNode(true));

			li.addEventListener("click", function (event) {
				var target = event.target;

				if (target.className === "delete") {
					target = target.parentNode;
					target.removeChild(event.target);
					inputField.value = target.innerHTML.trim();
					target.parentNode.removeChild(target);
				}
			});

			rightOl.appendChild(li);
		});

		rightColumn.appendChild(rightOl);

		var inputField = document.createElement("input");
		inputField.setAttribute("size", "40");
		inputField.setAttribute("autofocus", "");
		docFragment.appendChild(inputField);
		inputField.addEventListener('keypress', function (ev) {
			if (ev.keyCode === 13) {
				if (!inputField.value) {
					return;
				}
				var li = document.createElement("li");
				li.className = "entry";
				li.innerText = inputField.value;
				li.appendChild(removeImg.cloneNode(true));

				li.addEventListener("click", function (event) {
					var target = event.target;

					if (target.className === "delete") {
						target = target.parentNode;
						target.removeChild(event.target);
						inputField.value = target.innerHTML.trim();
						target.parentNode.removeChild(target);
					}
				});

				rightOl.appendChild(li);

				var selectedRadio = document.querySelector('input[name = "column-select"]:checked');

				if (selectedRadio.id === "select-left-column") {
					leftOl.appendChild(li);
				} else {
					rightOl.appendChild(li);
				}

				inputField.value = "";
			}
		});

		var button = document.createElement("button");
		button.innerHTML = "Add";

		button.addEventListener("click", function (event) {
			if (!inputField.value) {
				return;
			}
			var li = document.createElement("li");
			li.className = "entry";
			li.innerText = inputField.value;
			li.appendChild(removeImg.cloneNode(true));

			li.addEventListener("click", function (event) {
				var target = event.target;

				if (target.className === "delete") {
					target = target.parentNode;
					target.removeChild(event.target);
					inputField.value = target.innerText;
					target.parentNode.removeChild(target);
				}
			});

			rightOl.appendChild(li);

			var selectedRadio = document.querySelector('input[name = "column-select"]:checked');

			if (selectedRadio.id === "select-left-column") {
				leftOl.appendChild(li);
			} else {
				rightOl.appendChild(li);
			}

			inputField.value = "";
		});

		docFragment.appendChild(button);

		element.appendChild(docFragment);
	};
}

// SUBMIT THE CODE ABOVE THIS LINE

if (typeof module !== "undefined") {
	module.exports = solve;
}
