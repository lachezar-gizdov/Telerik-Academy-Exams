function solve(args){
    let arr = args,
        str = '';

    for(let i = 0; i < arr.length; i+=1 ){
        str+= arr[i];
    }

    console.log(str);
    let replaced = str.split(' ').join('');
    console.log(replaced);

    
}

solve([
    'hello;',
    '{this; is',
    ' ; an;;;example;',
    '}',
    'of;',
    '{',
    'KONPOT;',
    '{',
    'Some_numbers;',
    '42;5;3}',
    '_}'
])