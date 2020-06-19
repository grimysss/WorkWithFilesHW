using Alturos.Yolo;
using OpenCvSharp;

namespace Controls
{
    public class Detector
    {
        private YoloWrapper _wrapper;


        public Detector(string pathToCfg, string pathToWeights, string pathToNames)
        {
            _wrapper = new YoloWrapper(pathToCfg, pathToWeights, pathToNames)
;
        }

        public Mat Detect(Mat img)
        {
            var items = _wrapper.Detect(img.ToBytes());
            return img;
        }
    }
}
