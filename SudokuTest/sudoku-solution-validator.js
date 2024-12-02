function validSolution(sudoku) {
    for(let i = 0; i < 9; i++) {
        if(!areTheElementsOfLineUnique(sudoku[i])) {
            return false;
        }
        if(!areTheElementsOfLineUnique(getColumnByIndex(sudoku, i))) {
            return false;
        }
    }

    for(let rowIndex = 0; rowIndex < 9; rowIndex += 3) {
        for(let columnIndex = 0; columnIndex < 9; columnIndex += 3) {
            const block = getBlockAsLineByStartIndexes(sudoku, rowIndex, columnIndex)
            if(!areTheElementsOfLineUnique(block) || block.includes(0)) {
                return false;
            }
        }
    }

    return true;
}

function getColumnByIndex(sudoku, index) {
    const column = [];
    for(let row = 0; row < 9; row++) {
        column.push(sudoku[row][index])
    }

    return column;
}

function areTheElementsOfLineUnique(line) {
    const uniqueElements = new Set(line);
    return uniqueElements.size === 9;
}

function getBlockAsLineByStartIndexes(sudoku, row, column)
{
    const block = [];
    for(let i = row; i < row + 3; i++) {
        for(let j = column; j < column + 3; j++) {
            block.push(sudoku[i][j]);
        }
    }

    return block;
}
  

export { validSolution };