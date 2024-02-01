const includedCategories = ['OM_Azonosito', 'Neve', 'Matematika', 'Magyar', 'Összesen'];
let sortOrder = {};

function sortTableByColumn(column) {
    let ascending = sortOrder[column] = !sortOrder[column];

    diakok.sort((a, b) => {
        if (column === 'Összesen') {
            return (ascending ? 1 : -1) * ((a.Matematika + a.Magyar) - (b.Matematika + b.Magyar));
        } else {
            if (a[column] < b[column]) return ascending ? -1 : 1;
            if (a[column] > b[column]) return ascending ? 1 : -1;
            return 0;
        }
    });

    buildTable(diakok);
}

window.sortTableByColumn = sortTableByColumn;

function buildTable(data) {
    var table = document.querySelector('table');
    var tableHTML = "<thead><tr>";

    includedCategories.forEach(category => {
        let visualCategory = category;
        if (visualCategory === "OM_Azonosito") {
            visualCategory = 'OM Azonosító';
        } else if (visualCategory === "Neve") {
            visualCategory = 'Név';
        }
        tableHTML += `<th onclick="window.sortTableByColumn('${category}')">${visualCategory}</th>`;
    });

    tableHTML += "</tr></thead><tbody>";

    data.forEach(function (row) {
        tableHTML += "<tr>";
        includedCategories.forEach(category => {
            let cellValue;
            if (category === 'Összesen') {
                let MatematikaScore = Number(row.Matematika);
                let MagyarScore = Number(row.Magyar);
                cellValue = (!isNaN(MatematikaScore) ? MatematikaScore : 0) + (!isNaN(MagyarScore) ? MagyarScore : 0);
            } else {
                cellValue = row[category];
            }
            tableHTML += `<td>${cellValue}</td>`;
        });
        tableHTML += "</tr>";
    });

    tableHTML += "</tbody>";
    table.innerHTML = tableHTML;
}

document.addEventListener('DOMContentLoaded', function () {
    buildTable(diakok);
});

function filterByMinimumPoints(minPoints) {
    return diakok.filter(diak => {
        const matematikaPoints = Number(diak.Matematika);
        const magyarPoints = Number(diak.Magyar);
        const totalPoints = matematikaPoints + magyarPoints;
        return totalPoints >= minPoints;
    });
}

document.addEventListener('DOMContentLoaded', function () {
    const minPointsInput = document.getElementById('minCombinedPointsInput');


    minPointsInput.addEventListener('input', function () {
        const minPoints = Number(minPointsInput.value);
        if (!isNaN(minPoints) && minPoints > 0) {
            const filteredDiakok = filterByMinimumPoints(minPoints);
            if (minPoints == null) {
                buildTable(0);
            }
            else {
                
                buildTable(filteredDiakok);
            }
        }
    });

    buildTable(diakok);
});