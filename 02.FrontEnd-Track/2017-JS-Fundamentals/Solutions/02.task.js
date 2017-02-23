function solve(args) {
    let dimensions = args[0].split(' ').map(Number),
        mazeRow = dimensions[0],
        mazeCol = dimensions[1],
        maze = [];

    for (let i = 1; i <= mazeRow; i += 1) {
        maze.push(args[i].split(' ').map(Number));
    }
    let posRow = Math.floor(mazeRow / 2),
        posCol = Math.floor(mazeCol / 2),
        position = maze[posRow][posCol];

    while (true) {
        maze[posRow][posCol] = false;
        let bin = (position).toString(2);
        let arr = (('0000' + bin).substring(bin.length)).split('').map(Number);
        if ((arr[3] === 1) && (maze[posRow - 1][posCol] !== false)) {
            posRow -= 1;
        }
        else if ((arr[2] === 1) && (maze[posRow][posCol + 1] !== false)) {
            posCol += 1;
        }
        else if ((arr[1] === 1) && (maze[posRow + 1][posCol] !== false)) {
            posRow += 1;
        }
        else if ((arr[0] === 1) && (maze[posRow][posCol - 1] !== false)) {
            posCol -= 1;
        }
        else {
            console.log("No JavaScript, only rakiya " + posRow + ' ' + posCol);
            break;
        }
        if ((posRow < 0 || posRow > mazeRow - 1) || (posCol < 0 || posCol > mazeCol - 1)) {
            console.log('No rakiya, only JavaScript ' + posRow + ' ' + posCol)
            break;
        }
        position = maze[posRow][posCol];
        if (position === false) {
            console.log("No JavaScript, only rakiya " + posRow + ' ' + posCol);
            break;
        }
    }
}

solve([
    '5 7',
    '9 5 3 11 9 5 3',
    '10 11 10 12 4 3 10',
    '10 10 12 7 13 6 10',
    '12 4 3 9 5 5 2',
    '13 5 4 6 13 5 6'
]);

solve([
    '7 5',
    '9 3 11 9 3',
    '10 12 4 6 10',
    '12 3 13 1 6',
    '9 6 11 12 3',
    '10 9 6 13 6',
    '10 12 5 5 3',
    '12 5 5 5 6'
]);