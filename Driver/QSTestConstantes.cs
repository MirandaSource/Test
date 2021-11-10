using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Drivers
{
    class QSTestConstantes
    {

        //Palabras reservadas de cucumber
        public const String GIVEN = "Given";

        public const String WHEN = "When";

        public const String THEN = "Then";

        public const String AND = "And";
        //URL
        public const String URLSERVER = "https://www.demoblaze.com/index.html";
        //Ligas para guardar imagen, reporte y screenshot
        public const String URL_IMG = @"C:/BauFest/ExtentReport/Img.jpg";

        public const string URL_REPORT = @"C:/BauFest/ExtentReport/";

        public const String URL_REPORT_SS = @"C:/BauFest/ExtentReport/ScreenShots/";
    }
}
