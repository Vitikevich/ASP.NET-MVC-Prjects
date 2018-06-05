namespace UseXPagedListMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class UsersContext : DbContext
    {
        // Контекст настроен для использования строки подключения "UsersContext" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "UseXPagedListMVC.Models.UsersContext" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "UsersContext" 
        // в файле конфигурации приложения.
        public UsersContext()
            : base("name=UsersDB")
        {
        }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
    }
}