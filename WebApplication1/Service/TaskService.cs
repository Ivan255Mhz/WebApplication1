using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class TaskService
    {
        private readonly List<TaskItem> _tasks = new();
        private int _id = 1;

        public List<TaskItem> GetAll()
        {
            Console.WriteLine("📥 Получение всех задач");
            return _tasks;
        }

        public TaskItem Create(string title)
        {
            Console.WriteLine($"📨 Создание задачи: {title}");

            var task = new TaskItem
            {
                Id = _id++,
                Title = title,
                IsDone = false,
                CreatedAt = DateTime.Now
            };

            _tasks.Add(task);

            Console.WriteLine("✅ Задача добавлена");

            return task;
        }

        public TaskItem? Toggle(int id)
        {
            Console.WriteLine($"🔄 Переключение задачи {id}");

            var task = _tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                Console.WriteLine("❌ Задача не найдена");
                return null;
            }

            task.IsDone = !task.IsDone;

            Console.WriteLine("✅ Статус изменён");

            return task;
        }

        public bool Delete(int id)
        {
            Console.WriteLine($"🗑 Удаление задачи {id}");

            var task = _tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                Console.WriteLine("❌ Задача не найдена");
                return false;
            }

            _tasks.Remove(task);

            Console.WriteLine("✅ Удалено");

            return true;
        }
    }
}
