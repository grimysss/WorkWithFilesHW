using System;
using System.Collections.Generic;
using System.Linq;
using Alturos.Yolo;
using OpenCvSharp;

namespace Controls
{
    class Detector
    {
        #region Data

        private YoloWrapper _wrapper;
        private LogControler _logControler;

        #endregion

        #region .ctor

        /// <summary> Создаем контроллер детектора. </summary>
        /// <param name="logControler"> Контролер лога. </param>
        public Detector(LogControler logControler)
        {
            _logControler = logControler;

            _wrapper = new YoloWrapper(@"C:\Users\grimy\Desktop\yolo3\yolov3_training_test.cfg",
                                       @"C:\Users\grimy\Desktop\yolo3\yolov3_training_final_not.weights",
                                       @"C:\Users\grimy\Desktop\yolo3\obj.names");
        }

        //public Detector()
        //{
        //    _wrapper = new YoloWrapper(@"C:\Users\grimy\Desktop\yolov4\yolov4.cfg",
        //                               @"C:\Users\grimy\Desktop\yolov4\yolov4.weights",
        //                               @"C:\Users\grimy\Desktop\yolov4\coco.names");
        //}

        //public Detector()
        //{
        //    _wrapper = new YoloWrapper(@"C:\Users\grimy\Desktop\YOLO-Tiny-v3\yolov3-tiny.cfg",
        //                               @"C:\Users\grimy\Desktop\YOLO-Tiny-v3\yolov3-tiny.weights",
        //                               @"C:\Users\grimy\Desktop\YOLO-Tiny-v3\coco.names");
        //}

        #endregion

        #region Methods

        public IEnumerable<Alturos.Yolo.Model.YoloItem> GetInfoAboutDetection(string path)
        {
            return _wrapper.Detect(new Mat(path).ToBytes());
        }

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

                    Rect rect = new Rect(xmin, ymin, width, height);
                    img.Rectangle(rect, Scalar.Blue, 3, LineTypes.AntiAlias, 0);

                    //_logControler.AddMessage($@"Тип объекта: {items.ElementAt(i).Type.ToString()}");
                    //_logControler.AddMessage($@"X: {xmin}, Y: {ymin}, Width: {width}, Height: {height}");
                    //_logControler.AddMessage($@"Уверенность: {items.ElementAt(i).Confidence.ToString("#0.##%")}");

                    // Выводим в лог тип объекта, его положение и уверенность обнаружения.
                    _logControler.AddMessage($@"Тип объекта: {items.ElementAt(i).Type.ToString()}  X: {xmin}, Y: {ymin}, Width: {width}, Height: {height}  Уверенность: {items.ElementAt(i).Confidence.ToString("#0.##%")}");
                }
            }
            return img;
        }

        #endregion

    }
}
