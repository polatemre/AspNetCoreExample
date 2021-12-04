using ImageMagick;

namespace CustomRouteHandler.Handlers
{
    public class ImageHandler
    {
        public RequestDelegate Handler(string filePath)
        {
            return async c =>
            {
                FileInfo fileInfo = new FileInfo($"{filePath}\\{c.Request.RouteValues["imageName"].ToString()}");
                using MagickImage magick = new MagickImage(fileInfo);

                int width = magick.Width, height = magick.Height;

                if (!string.IsNullOrEmpty(c.Request.Query["w"].ToString()))
                    width = int.Parse(c.Request.Query["w"].ToString());
                if (!string.IsNullOrEmpty(c.Request.Query["h"].ToString()))
                    height = int.Parse(c.Request.Query["h"].ToString());

                magick.Resize(width, height); // resize işlemi bitti

                // response ederken png formatında geriye döndürme işlemi gerçekleştiriyoruz.
                var buffer = magick.ToByteArray();
                c.Response.Clear();
                c.Response.ContentType = String.Concat("image/", fileInfo.Extension.Replace(".", "")); // type'ı bildiriyoruz: image/png, image/jpg gibi

                await c.Response.Body.WriteAsync(buffer, 0, buffer.Length); 
                await c.Response.WriteAsync(filePath); 
            };
        }
    }
}
