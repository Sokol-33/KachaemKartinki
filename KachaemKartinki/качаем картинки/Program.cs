using System.Diagnostics;

internal class Program
{
    private static async Task Main(string[] args)
    {
        // Создается экземпляр HttpClient, который используется для отправки HTTP-запросов и получения ответов от сервера.
        HttpClient client = new();
        //В консоли выводится сообщение "Введите ссылку для скачивания картинки: ".
        Console.WriteLine("Введите ссылку для скачивания картинки: ");
        //Вводится ссылка для скачивания картинки с помощью Console.ReadLine().
        string nameWebsite = Console.ReadLine();
        //Отправляется GET-запрос на указанную ссылку с использованием client.GetAsync(nameWebsite).
        HttpResponseMessage response = await client.GetAsync(nameWebsite);
        //Получается ответ от сервера в виде экземпляра HttpResponseMessage.
        byte[] data = await response.Content.ReadAsByteArrayAsync();
        //Данные из ответа читаются в виде массива байтов с помощью response.Content.ReadAsByteArrayAsync().
        await File.WriteAllBytesAsync("C:\\Users\\ПК\\Downloads\\Ram.jpg", data);
        //Полученные данные записываются в файл "C:\\Users\\ПК\\Downloads\\Ram.jpg" с помощью File.WriteAllBytesAsync().
        Process.Start(new ProcessStartInfo { FileName = "C:\\Users\\ПК\\Downloads\\Ram.jpg", UseShellExecute = true });
        //Запускается приложение для просмотра изображения, используя приложение по умолчанию, связанное с типом файла .jpg, с помощью Process.Start().
    }
}

