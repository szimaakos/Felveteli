let diakokFilter = [];
omIdInput.addEventListener('input', function () {
    if (this.value.length > 11) {
        this.value = this.value.slice(0, 11);
    }
    if (this.value.includes('-')) {
        this.value = ''
    }
    if (this.value.includes('e')) {
        this.value = ''
    }
    const omId = document.getElementById('omIdInput').value;

    searchOmIdMultiple(omId);
    calculateAverages();

});

function searchOmIdMultiple(omId) {
    const results = diakok.filter(diak => diak.OM_Azonosito.includes(omId));
    diakokFilter = results;
    console.log('Results:', results);

    const table = document.getElementById('resultTable');
    table.innerHTML = '';

    const createTableHeader = () => {
        const thead = document.createElement('thead');
        const headerRow = document.createElement('tr');
        Object.keys(results[0]).forEach(key => {
            console.log('Key:', key);
            const headerCell = document.createElement('th');
            if (key == "OM_Azonosito") {
                headerCell.textContent = 'OM Azonosító';
            }
            else if (key == "Neve") {
                headerCell.textContent = 'Név';
            }
            else if (key == "ErtesitesiCime") {
                headerCell.textContent = 'Értesítési cím';
            }
            else if (key == "SzuletesiDatum") {
                headerCell.textContent = 'Születési dátum';
            }
            else {

                headerCell.textContent = key;
            }
            headerRow.appendChild(headerCell);
        });
        thead.appendChild(headerRow);
        table.appendChild(thead);
        console.log('Table head:', thead);
    };

    const createTableBody = () => {
        results.forEach(result => {
            const tbody = document.createElement('tbody');
            const bodyRow = document.createElement('tr');
            bodyRow.classList.add('trElement');
            

            Object.entries(result).forEach(([key, value]) => {
                const bodyCell = document.createElement('td');
                const span = document.createElement('span');
                if (key == "OM_Azonosito") {
                    span.textContent = 'OM Azonosító: ';
                }
                else if (key == "Neve") {
                    span.textContent = 'Név: ';
                }
                else if (key == "ErtesitesiCime") {
                    span.textContent = 'Értesítési cím: ';
                }
                else if (key == "SzuletesiDatum") {
                    span.textContent = 'Születési dátum: ';
                }
                else {
    
                    span.textContent = key+": ";
                }                
                span.classList.add('mobile');
                bodyCell.appendChild(span);
                bodyCell.appendChild(document.createTextNode(value));
                bodyCell.classList.add('bodyCell');
                bodyRow.appendChild(bodyCell);
            });

            
            tbody.appendChild(bodyRow);
            table.appendChild(tbody);
        });
        console.log('Table body:', table);
    };

    if (results.length > 0) {
        createTableHeader();
        createTableBody();
    } else {
        table.innerHTML = 'Nincs találat az adott OM Azonosítóra.';
        console.log('No results found.');
    }
}

function calculateAverages() {
    const matematikaSum = diakokFilter.reduce((sum, diak) => sum + Number(diak.Matematika), 0);
    const magyarSum = diakokFilter.reduce((sum, diak) => sum + Number(diak.Magyar), 0);
    const matematikaAvg = matematikaSum / diakokFilter.length;
    const magyarAvg = magyarSum / diakokFilter.length;

    document.getElementById("matematikaAtlag").textContent = matematikaAvg.toFixed(2);
    document.getElementById("magyarAtlag").textContent = magyarAvg.toFixed(2);
}

