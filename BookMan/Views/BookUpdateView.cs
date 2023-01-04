//using Framework;
//using System;
//namespace BookMan.ConsoleApp.Views
//{
//    using Models;
//    internal class BookUpdateView
//    {
//        protected Book Model;
//        public BookUpdateView(Book model)
//        {
//            Model = model;
//        }
//        public void Render()
//        {
//            ViewHelp.WriteLine("UPDATE BOOK INFORMATION", ConsoleColor.Green); //sử dụng phương thức static
//            var authors = ViewHelp.InputString("Authors", Model.Authors);
//            var title = ViewHelp.InputString("Title", Model.Title);
//            var publisher = ViewHelp.InputString("Publisher", Model.Publisher);
//            var isbn = ViewHelp.InputString("Isbn", Model.Isbn);
//            var tags = ViewHelp.InputString("Tags", Model.Tags);
//            var description = ViewHelp.InputString("Description", Model.Description);
//            var file = ViewHelp.InputString("File", Model.File);
//            var year = ViewHelp.InputInt("Year", Model.Year);
//            var edition = ViewHelp.InputInt("Edition", Model.Edition);
//            var rating = ViewHelp.InputInt("Rate", Model.Rating);
//            var reading = ViewHelp.InputBool("Reading", Model.Reading);
//        }
//    }
//}

using System;
namespace BookMan.ConsoleApp.Views
{
    using BookMan.ConsoleApp.FrameWork;
    using Framework;
    using Models;
    using System.Reflection;

    internal class BookUpdateView : ViewBase
    {
        public BookUpdateView(Book model) : base(model) { }
        public void Render()
        {
            ViewHelp.WriteLine("UPDATE BOOK INFORMATION", ConsoleColor.Green);
            // chuyển đổi kiểu từ object sang Book, chỉ áp dụng với kiểu class
            var model = Model as Book;
            var authors = ViewHelp.InputString("Authors", model.Authors);
            var title = ViewHelp.InputString("Title", model.Title);
            var publisher = ViewHelp.InputString("Publisher", model.Publisher);
            var isbn = ViewHelp.InputString("Isbn", model.Isbn);
            var tags = ViewHelp.InputString("Tags", model.Tags);
            var description = ViewHelp.InputString("Description", model.Description);
            var file = ViewHelp.InputString("File", model.File);
            var year = ViewHelp.InputInt("Year", model.Year);
            var edition = ViewHelp.InputInt("Edition", model.Edition);
            var rating = ViewHelp.InputInt("Rate", model.Rating);
            var reading = ViewHelp.InputBool("Reading", model.Reading);
        }
    }
}