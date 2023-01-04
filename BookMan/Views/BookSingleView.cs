﻿using System;
using Framework;
namespace BookMan.ConsoleApp.Views // chú ý cách Visual Studio đặt tên namespace
{
    using Models; // chú ý cách dùng using bên trong namespace
    /// <summary>
    /// class để hiển thị một cuốn sách
    /// </summary>
    internal class BookSingleView
    {
        protected Book Model; // biến này để lưu trữ thông tin cuốn sách đang cần hiển thị
        /// <summary>
        /// đây là hàm tạo, sẽ được gọi đầu tiên khi tạo object
        /// </summary>
        /// <param name="model">cuốn sách cụ thể sẽ được hiển thị</param>
        public BookSingleView(Book model)
        {
            Model = model; // chuyển dữ liệu từ tham số sang biến thành viên để sử dụng trong toàn class            
        }
        /// <summary>
        /// thực hiện in thông tin ra màn hình console
        /// </summary>
        public void Render()
        {
            if (Model == null) // kiếm tra xem có dữ liệu không
            {
                // sử dụng phương thức tĩnh WriteLine của lớp ViewHelp
                ViewHelp.WriteLine("NO BOOK FOUND. SORRY!", ConsoleColor.Red);
                return; // kết thúc thực hiện phương thức (bỏ qua phần còn lại)
            }
            // sử dụng phương thức tĩnh WriteLine của lớp ViewHelp
            ViewHelp.WriteLine("BOOK DETAIL INFORMATION", ConsoleColor.Green);
            /* các dòng dưới đây viết ra thông tin cụ thể theo từng dòng
             * sử dụng cách tạo xâu kiểu "interpolation"
             * và dùng dấu cách để căn chỉnh tạo thẩm mỹ
             */
            Console.WriteLine($"Authors:     {Model.Authors}");
            Console.WriteLine($"Title:       {Model.Title}");
            Console.WriteLine($"Publisher:   {Model.Publisher}");
            Console.WriteLine($"Year:        {Model.Year}");
            Console.WriteLine($"Edition:     {Model.Edition}");
            Console.WriteLine($"Isbn:        {Model.Isbn}");
            Console.WriteLine($"Tags:        {Model.Tags}");
            Console.WriteLine($"Description: {Model.Description}");
            Console.WriteLine($"Rating:      {Model.Rating}");
            Console.WriteLine($"Reading:     {Model.Reading}");
            Console.WriteLine($"File:        {Model.File}");
            Console.WriteLine($"File Name:   {Model.FileName}");
        }
    }
}