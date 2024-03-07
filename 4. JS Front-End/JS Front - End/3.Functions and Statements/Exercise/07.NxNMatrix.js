function matrix(num){
    for (let row = 0; row < num; row++) {
        let roww = ``;
        for (let col = 0; col < num; col++) {
            roww += num.toString() + ` `;         
        }    
        console.log(roww.trim());
    }
}

matrix(3);
matrix(7);
matrix(2);