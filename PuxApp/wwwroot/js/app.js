const pathInput = document.getElementById("pathInput");
const analyseButton = document.getElementById("analyseButton");
const resultContainer = document.getElementById("result");

analyseButton.addEventListener("click", analyseDirectory);

async function analyseDirectory()
{
    const path = pathInput.value.trim();

    if (!path) {
        resultContainer.innerHTML = `<p class="error">Zadej cestu k adresáři.</p>`;
        return;
    }

    resultContainer.innerHTML = `<p>Probíhá analýza...</p>`;

    try {
        const response = await fetch("/api/analyse", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify({ path })
        });

        const data = await response.json();

        if (!response.ok) {
            resultContainer.innerHTML = `<p class="error">${data.error ?? "Nastala chyba."}</p>`;
            return;
        }

        renderResult(data);
    } catch (error) {
        resultContainer.innerHTML = `<p class="error">Nepodařilo se kontaktovat server.</p>`;
    }
}
function renderResult(data) {
    resultContainer.innerHTML = `
        <h2>Výsledek analýzy</h2>
        <p>První spuštění: ${data.isInitialScan ? "Ano" : "Ne"}</p>

        ${renderFileSection("Nové soubory", data.newFiles)}
        ${renderFileSection("Změněné soubory", data.modifiedFiles)}
        ${renderTextSection("Odstraněné soubory", data.deletedFiles)}
        ${renderTextSection("Odstraněné podadresáře", data.deletedDirectories)}
    `;
}

function renderFileSection(title, items) {
    if (!items || items.length === 0) {
        return `
            <section>
                <h3>${title}</h3>
                <p>Žádné položky.</p>
            </section>
        `;
    }

    const listItems = items
        .map(item => `<li>${item.relativePath} (verze ${item.version})</li>`)
        .join("");

    return `
        <section>
            <h3>${title}</h3>
            <ul>${listItems}</ul>
        </section>
    `;
}

function renderTextSection(title, items) {
    if (!items || items.length === 0) {
        return `
            <section>
                <h3>${title}</h3>
                <p>Žádné položky.</p>
            </section>
        `;
    }

    const listItems = items
        .map(item => `<li>${item}</li>`)
        .join("");

    return `
        <section>
            <h3>${title}</h3>
            <ul>${listItems}</ul>
        </section>
    `;
}