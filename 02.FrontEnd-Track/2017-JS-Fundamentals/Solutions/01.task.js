function solve(args) {
    let arr = [...args].map(Number),
        result = arr[1],
        len = arr.length;

    for (let i = 2; i < len; i += 1) {
            if (Math.abs(arr[i]) % 2 !== 0) {
            result *= arr[i];
            result = result % 1024;
        }
        else {
            result += arr[i];
            result = result % 1024;
            i += 1;
        }
    }
    console.log(result);
}

solve([
  '9',
  '9',
  '9',
  '9',
  '9',
  '9',
  '9',
  '9',
  '9',
  '9'
]);