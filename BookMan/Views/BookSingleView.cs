//using System;
//using Framework;
//namespace BookMan.ConsoleApp.Views // chú ý cách Visual Studio đặt tên namespace
//{
//    using Models; // chú ý cách dùng using bên trong namespace
//    /// <summary>
//    /// class để hiển thị một cuốn sách
//    /// </summary>
//    internal class BookSingleView
//    {
//        protected Book Model; // biến này để lưu trữ thông tin cuốn sách đang cần hiển thị
//        /// <summary>
//        /// đây là hàm tạo, sẽ được gọi đầu tiên khi tạo object
//        /// </summary>
//        /// <param name="model">cuốn sách cụ thể sẽ được hiển thị</param>
//        public BookSingleView(Book model)
//        {
//            Model = model; // chuyển dữ liệu từ tham số sang biến thành viên để sử dụng trong toàn class            
//        }
//        /// <summary>
//        /// thực hiện in thông tin ra màn hình console
//        /// </summary>
//        public void Render()
//        {
//            if (Model == null) // kiếm tra xem có dữ liệu không
//            {
//                // sử dụng phương thức tĩnh WriteLine của lớp ViewHelp
//                ViewHelp.WriteLine("NO BOOK FOUND. SORRY!", ConsoleColor.Red);
//                return; // kết thúc thực hiện phương thức (bỏ qua phần còn lại)
//            }
//            // sử dụng phương thức tĩnh WriteLine của lớp ViewHelp
//            ViewHelp.WriteLine("BOOK DETAIL INFORMATION", ConsoleColor.Green);
//            /* các dòng dưới đây viết ra thông tin cụ thể theo từng dòng
//             * sử dụng cách tạo xâu kiểu "interpolation"
//             * và dùng dấu cách để căn chỉnh tạo thẩm mỹ
//             */
//            Console.WriteLine($"Authors:     {Model.Authors}");
//            Console.WriteLine($"Title:       {Model.Title}");
//            Console.WriteLine($"Publisher:   {Model.Publisher}");
//            Console.WriteLine($"Year:        {Model.Year}");
//            Console.WriteLine($"Edition:     {Model.Edition}");
//            Console.WriteLine($"Isbn:        {Model.Isbn}");
//            Console.WriteLine($"Tags:        {Model.Tags}");
//            Console.WriteLine($"Description: {Model.Description}");
//            Console.WriteLine($"Rating:      {Model.Rating}");
//            Console.WriteLine($"Reading:     {Model.Reading}");
//            Console.WriteLine($"File:        {Model.File}");
//            Console.WriteLine($"File Name:   {Model.FileName}");
//        }
//        public void RenderToFile(string path)
//        {
//            ViewHelp.WriteLine($"Saving data to file '{path}'");
//            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
//            System.IO.File.WriteAllText(path, json);
//            ViewHelp.WriteLine("Done!");
//        }
//    }
//}

using System;
namespace BookMan.ConsoleApp.Views
{
    using BookMan.ConsoleApp.FrameWork;
    using Framework;
    using Models;
    internal class BookSingleView : ViewBase
    {
        public BookSingleView(Book model) : base(model) { }
        public void Render()
        {
            if (Model == null)
            {
                ViewHelp.WriteLine("NO BOOK FOUND. SORRY!", ConsoleColor.Red);
                return;
            }
            ViewHelp.WriteLine("BOOK DETAIL INFORMATION", ConsoleColor.Green);
            // chuyển đổi kiểu từ object sang Book, chỉ áp dụng với kiểu class
            var model = Model as Book;
            Console.WriteLine($"Authors:     {model.Authors}");
            Console.WriteLine($"Title:       {model.Title}");
            Console.WriteLine($"Publisher:   {model.Publisher}");
            Console.WriteLine($"Year:        {model.Year}");
            Console.WriteLine($"Edition:     {model.Edition}");
            Console.WriteLine($"Isbn:        {model.Isbn}");
            Console.WriteLine($"Tags:        {model.Tags}");
            Console.WriteLine($"Description: {model.Description}");
            Console.WriteLine($"Rating:      {model.Rating}");
            Console.WriteLine($"Reading:     {model.Reading}");
            Console.WriteLine($"File:        {model.File}");
            Console.WriteLine($"File Name:   {model.FileName}");
        }
        public void RenderToFile(string path)
        {
            ViewHelp.WriteLine($"Saving data to file '{path}'");
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(Model);
            System.IO.File.WriteAllText(path, json);
            ViewHelp.WriteLine("Done!");
        }
    }
}