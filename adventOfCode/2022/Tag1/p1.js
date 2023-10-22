const fs = require('fs')

fs.readFile('./input.txt', 'utf8', (err, data) => {
    if (err) {
        console.error(err)
        return
    }
    let value = 0
    let biggest = 0
    let lines = data.split('\r\n')
    lines.forEach(line => {

        if (line === "") {
            if (value > biggest){
                biggest = value
                
            } 
            value = 0
        } else {
            value = value + parseInt(line)
        }
    }) 
    console.log(biggest)
})

