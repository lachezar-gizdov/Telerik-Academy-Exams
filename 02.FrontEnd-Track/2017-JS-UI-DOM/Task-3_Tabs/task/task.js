function solve() {
	return `
<div class="tabs-controls">
	<ul class="list list-titles">
		{{#each titles}}
			<li class="list-item">
				<label for="{{link}}" class="title">{{text}}</label>
			</li>
		{{/each}}
	</ul>
	<ul class="list list-contents">
		{{#each contents}}
			<li class="list-item">
				{{#if contents.[0]}}
					<input class="tab-content-toggle" id="{{link}}" name="tab-toggles" checked="checked/" type="radio">
					{{else}}
					<input class="tab-content-toggle" id="{{link}}" name="tab-toggles" type="radio">
				{{/if}}
				<div class="content">
					{{{text}}}
				</div>
			</li>
		{{/each}}
	</ul>
</div>
	`;
}

if (typeof module !== 'undefined') {
	module.exports = solve;
}