document.getElementById('searchButton').addEventListener('click', function () {
    const omId = document.getElementById('omIdInput').value;

    if (omId.length === 11 && !isNaN(omId)) {
        searchOmId(omId);
    } else {
        alert('Kérlek, adj meg egy érvényes 11 számjegyből álló OM Azonosítót.');
    }
});

function searchOmId(omId) {
    const result = diakok.find(diak => diak.OM_Azonosito === omId);

    const table = document.getElementById('resultTable');
    table.innerHTML = '';

    if (result) {
        const thead = document.createElement('thead');
        const headerRow = document.createElement('tr');
        Object.keys(result).forEach(key => {
            const headerCell = document.createElement('th');
            headerCell.textContent = key;
            headerRow.appendChild(headerCell);
        });
        thead.appendChild(headerRow);
        table.appendChild(thead);

        const tbody = document.createElement('tbody');
        const bodyRow = document.createElement('tr');
        Object.values(result).forEach(value => {
            const bodyCell = document.createElement('td');
            bodyCell.textContent = value;
            bodyRow.appendChild(bodyCell);
        });
        tbody.appendChild(bodyRow);
        table.appendChild(tbody);
    } else {
        table.innerHTML = '';
        table.innerHTML = 'Nincs találat az adott OM Azonosítóra.';
    }
}
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
});