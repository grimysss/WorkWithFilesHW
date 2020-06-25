using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Alturos.Yolo;
using OpenCvSharp;

namespace Controls
{
    class Detector
    {
        #region Data

        private YoloWrapper _wrapper;
        private LogControler _logControler;
        private VideoPlayerControler _videoPlayerControler;

        #endregion

        #region .ctor

        public Detector(LogControler logControler, VideoPlayerControler videoPlayerControler)
        {
            _logControler = logControler;
            _videoPlayerControler = videoPlayerControler;

            _wrapper = new YoloWrapper(@"C:\Users\grimy\Desktop\yolo3\yolov3_training_test.cfg",
                                       @"C:\Users\grimy\Desktop\yolo3\yolov3_training_final_not.weights",
                                       @"C:\Users\grimy\Desktop\yolo3\obj.names");
        }

        #endregion

        #region Methods

        public Mat Detect(Mat img)
        {
            //var img = new Mat(path);
            var items = _wrapper.Detect(img.ToBytes());

            for (int i = 0; i < items.Count(); i++)
            {
                // Объекты будут отображаться только при уверенность больше 80%
                if (items.ElementAt(i).Confidence > 0.8)
                {
                    var xmin = Int32.Parse(items.ElementAt(i).X.ToString());
                    var ymin = Int32.Parse(items.ElementAt(i).Y.ToString());
                    var width = Int32.Parse(items.ElementAt(i).Width.ToString());
                    var height = Int32.Parse(items.ElementAt(i).Height.ToString());
                    var point = new Point(items.ElementAt(i).X + width / 2, items.ElementAt(i).Y + height / 2);
                    var frameCount = _videoPlayerControler.FrameCount;

                    //Если соберусь делать доп задание: идея. (1)
                    //var pt11 = 100;
                    //var pt12 = 300;
                    //var pt21 = 100;
                    //var pt22 = 10;

                    //Строим прямоугольник вокруг объекта.
                    Rect rect = new Rect(xmin, ymin, width, height);
                    img.Rectangle(rect, Scalar.Blue, 3, LineTypes.AntiAlias, 0);

                    //Строим точку в центре объекта.
                    //img.Circle(point, 2, Scalar.Blue, 2, LineTypes.AntiAlias, 0);

                    //Если соберусь делать доп задание: идея. (2) Строим линию для подсчета цвепок.
                    //img.Line(pt11, pt12, pt21, pt22, Scalar.Green, 2, LineTypes.AntiAlias, 0);

                    //_logControler.AddMessage($@"Номер кадра: {frameCount}");
                    //_logControler.AddMessage($@"Тип объекта: {items.ElementAt(i).Type.ToString()}");
                    //_logControler.AddMessage($@"X: {xmin}, Y: {ymin}, Width: {width}, Height: {height}");
                    //_logControler.AddMessage($@"Уверенность: {items.ElementAt(i).Confidence.ToString("#0.##%")}");
                    //_logControler.AddMessage($@"Центр объекта: {point}");

                    // Выводим в лог номер кадра, тип объекта, его положение, центр и уверенность обнаружения.
                    //_logControler.AddMessage($@"Номер кадра:  {frameCount},  Тип объекта: {items.ElementAt(i).Type},  X: {xmin}, Y: {ymin}, Width: {width}, Height: {height},  Центр объекта: { point},   Уверенность: {items.ElementAt(i).Confidence:#0.##%}");

                    // Укороченная версия.
                    _logControler.AddMessage($@"№ кадра:  {frameCount},  Объект: {items.ElementAt(i).Type},  X: {xmin}, Y: {ymin}, Width: {width}, Height: {height},  Центр: { point},   Уверенность: {items.ElementAt(i).Confidence:#0.##%}");

                }
            }
            return img;
        }

        #endregion

    }
}
