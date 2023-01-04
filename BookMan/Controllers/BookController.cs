using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BookMan.ConsoleApp.Controllers
{
    using DataServices;
    using Views;
    using Models;
    /// <summary>
    /// lớp điều khiển, giúp ghép nối dữ liệu sách với giao diện
    /// </summary>
    internal class BookController
    {
        protected Repository Repository;
        public BookController(SimpleDataAccess context)
        {
            Repository = new Repository(context);
        }
        /// <summary>
        /// ghép nối dữ liệu 1 cuốn sách với giao diện hiển thị 1 cuốn sách
        /// </summary>
        /// <param name="id">mã định danh của cuốn sách</param>
        public void Single(int id)
        {
            // lấy dữ liệu qua repository
            var model = Repository.Select(id);
            // khởi tạo view
            BookSingleView view = new BookSingleView(model);
            // gọi phương thức Render để thực sự hiển thị ra màn hình
            view.Render();
        }
        /// <summary>
        /// kích hoạt chức năng nhập dữ liệu cho 1 cuốn sách
        /// </summary>
        public void Create()
        {
            BookCreateView view = new BookCreateView();// khởi tạo object
            view.Render(); // hiển thị ra màn hình
        }
        /// <summary>
        /// kích hoạt chức năng hiển thị danh sách
        /// </summary>
        public void List()
        {
            // lấy dữ liệu qua repository
            var model = Repository.Select();
            // khởi tạo view
            BookListView view = new BookListView(model);
            view.Render();
        }
        /// <summary>
        /// kích hoạt chức năng cập nhật
        /// </summary>
        /// <param name="id"></param>
        public void Update(int id)
        {
            view.Render();
        }
    }
}