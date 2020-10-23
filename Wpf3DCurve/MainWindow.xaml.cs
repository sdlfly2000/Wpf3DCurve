using System.Windows;
using System.Windows.Input;

namespace Wpf3DCurve
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private double _startPositionX = 0d; 
        private double _startPositionY = 0d; 

        private bool isLeftButtonDown = false;

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            var currentPosition = e.GetPosition(this);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                Roate3DOjbect.Angle = currentPosition.X - _startPositionX;
            }
            else
            {
                _startPositionX = currentPosition.X;
                _startPositionY = currentPosition.Y;
            }
        }

        private void OnMouseWheel(object sender, MouseWheelEventArgs e)
        {
            var scaleRatio = 0.1d;
            if (e.Delta < 0)
            {
                scaleRatio = -scaleRatio;
            }

            Scale3DObject.ScaleX = GetScale(Scale3DObject.ScaleX, scaleRatio);
            Scale3DObject.ScaleY = GetScale(Scale3DObject.ScaleY, scaleRatio);
            Scale3DObject.ScaleZ = GetScale(Scale3DObject.ScaleZ, scaleRatio);
        }

        private double GetScale(double orginalSize, double addSize)
        {
            if (orginalSize > 0)
            {
                return orginalSize + addSize;
            }

            return orginalSize;
        }
    }
}
