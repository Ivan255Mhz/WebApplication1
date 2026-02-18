const api = "http://localhost:5071/api/tasks";

async function loadTasks() {
    console.log("📥 Загружаем задачи");

    const res = await fetch(api);
    const tasks = await res.json();

    const container = document.getElementById("tasks");
    container.innerHTML = "";

    tasks.forEach(t => {
        container.innerHTML += `
            <div class="task ${t.isDone ? "done" : ""}">
                ${t.title}
                <br>
                <button onclick="toggle(${t.id})">✔</button>
                <button onclick="removeTask(${t.id})">🗑</button>
            </div>
        `;
    });
}

async function addTask() {
    const title = document.getElementById("taskInput").value;

    console.log("📨 Добавляем задачу");

    await fetch(api, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({ title })
    });

    loadTasks();
}

async function toggle(id) {
    await fetch(`${api}/${id}`, { method: "PUT" });
    loadTasks();
}

async function removeTask(id) {
    await fetch(`${api}/${id}`, { method: "DELETE" });
    loadTasks();
}

loadTasks();
