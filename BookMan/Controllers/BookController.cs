//namespace BookMan.ConsoleApp.Controllers
//{
//    using DataServices;
//    using Views;
//    using Models;
//    /// <summary>
//    /// lớp điều khiển, giúp ghép nối dữ liệu sách với giao diện
//    /// </summary>
//    internal class BookController
//    {
//        protected Repository Repository;
//        public BookController(SimpleDataAccess context)
//        {
//            Repository = new Repository(context);
//        }

//        /// <summary>
//        /// ghép nối dữ liệu 1 cuốn sách với giao diện hiển thị 1 cuốn sách
//        /// </summary>
//        /// <param name="id">mã định danh của cuốn sách</param>
//        public void Single(int id, string path = "")
//        {
//            // lấy dữ liệu qua repository
//            var model = Repository.Select(id);
//            // khởi tạo view
//            BookSingleView view = new BookSingleView(model);
//            // gọi phương thức Render để thực sự hiển thị ra màn hình
//            if (!string.IsNullOrEmpty(path)) { view.RenderToFile(path); return; }
//            view.Render();
//        }
//        /// <summary>
//        /// kích hoạt chức năng hiển thị danh sách
//        /// </summary>
//        /// <summary>
//        /// kích hoạt chức năng hiển thị danh sách
//        /// </summary>
//        public void List(string path = "")
//        {
//            // lấy dữ liệu qua repository
//            var model = Repository.Select();
//            // khởi tạo view
//            BookListView view = new BookListView(model);
//            if (!string.IsNullOrEmpty(path)) { view.RenderToFile(path); return; }
//            view.Render();
//        }
//        /// <summary>
//        /// kích hoạt chức năng cập nhật
//        /// </summary>
//        /// <param name="id"></param>
//        public void Update(int id)
//        {
//            var model = Repository.Select(id);
//            var view = new BookUpdateView(model);
//            view.Render();
//        }
//    }
//}
namespace BookMan.ConsoleApp.Controllers
{
    using BookMan.ConsoleApp.Models;
    using DataServices;
    using Framework;
    using Views;
    internal class BookController : ControllerBase
    {
        protected Repository Repository;
        public BookController(SimpleDataAccess context)
        {
            Repository = new Repository(context);
        }
        public void Single(int id, string path = "")
        {
            var model = Repository.Select(id);
            Render(new BookSingleView(model), path);
        }
        public void Create(Book book = null)
        {
            if (book == null)
            {
                Render(new BookCreateView());
                return;
            }
            Repository.Insert(book);
            Success("Book created!");
        }
        public void List(string path = "")
        {
            var model = Repository.Select();
            Render(new BookListView(model), path);
        }
        public void Update(int id, Book book = null)
        {
            if (book == null)
            {
                var model = Repository.Select(id);
                var view = new BookUpdateView(model);
                Render(view);
                return;
            }
            Repository.Update(id, book);
            Success("Book updated!");
        }
        public void Delete(int id, bool process = false)
        {
            if (process == false)
            {
                var b = Repository.Select(id);
                Confirm($"Do you want to delete this book ({b.Title})? ", $"do delete?id={b.Id}");
            }
            else
            {
                Repository.Delete(id);
                Success("Book deleted!");
            }
        }

        public void Filter(string key)
        {
            var model = Repository.Select(key);
            if (model.Length == 0)
                Inform("No matched book found!");
            else
                Render(new BookListView(model));
        }

        public void Mark(int id, bool read = true)
        {
            var book = Repository.Select(id);
            if (book == null)
            {
                Error("Book not found!");
                return;
            }
            book.Reading = read;
            Success($"The book '{book.Title}' are marked as {(read ? "READ" : "UNREAD")}");
        }
        public void ShowMarks()
        {
            var model = Repository.SelectMarked();
            var view = new BookListView(model);
            Render(view);
        }
    }

    
}
