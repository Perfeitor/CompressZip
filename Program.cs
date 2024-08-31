using System.IO.Compression;

class Program
{
    static void Main(string[] args)
    {
        //Yêu cầu cmd sử dụng UTF-8
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        //Kiểm tra số lượng đầu vào
        if (args.Length != 1)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Vui lòng kéo folder cần nén vào file thực thi");
            Console.ReadLine();
            return;
        }

        //Lấy đường dẫn thư mục
        string folderPath = args[0];

        //Kiểm tra xem thư mục có tồn tại không
        if (!Directory.Exists(folderPath))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Thư mục không tồn tại");
            Console.ReadLine();
            return;
        }

        // Xác định tên và đường dẫn file ZIP sẽ được tạo ra
        string zipFilePath = Path.Combine(Path.GetDirectoryName(folderPath), Path.GetFileName(folderPath) + ".zip");


        //Bắt đầu quy trình nén
        try
        {
            // Xóa file ZIP nếu đã tồn tại
            if (File.Exists(zipFilePath))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Phát hiện file trùng lặp, tiến hành xoá...");
                File.Delete(zipFilePath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Đã xoá");
            }

            // Tạo file ZIP từ thư mục
            ZipFile.CreateFromDirectory(folderPath, zipFilePath, CompressionLevel.Optimal, includeBaseDirectory: false);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Thư mục ở '{folderPath}' đã được nén thành file zip ở '{zipFilePath}'");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            // Xử lý lỗi nếu có
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
