const fs = require('fs')

fs.readFile('./input.txt', 'utf8', (err, data) => {
    if (err) {
        console.error(err)
        return
    }
    let value = 0
    let ranking = []
    let lines = data.split('\r\n')
    lines.forEach(line => {

        if (line === "") {
            ranking.push(value)
            value = 0
        } else {
            value = value + parseInt(line)
        }
    })
    ranking.sort((a, b) => b - a)

    console.log(ranking[0] + ranking[1] + ranking[2])
})

