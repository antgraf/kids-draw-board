
namespace DrawBoard
{
    public partial class DrawBoardForm : Form
    {
        #region Internal

        private Pen? _pen;
        private Pen Pen { get => _pen ?? throw new InvalidOperationException("Color is not set"); }

        public DrawBoardForm()
        {
            InitializeComponent();

            Paint += DrawBoardForm_Paint;
        }

        private void DrawBoardForm_Paint(object? sender, PaintEventArgs e)
        {
            // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-draw-a-line-on-a-windows-form
            _pen = new Pen(Color.FromArgb(255, 0, 0, 0));
            try
            {
                Draw(e.Graphics);
            }
            finally
            {
                Pen?.Dispose();
                _pen = null;
            }
        }

        private void SetColor(Color color, float width = 1)
        {
            _pen?.Dispose();
            _pen = new(color, width);
        }

        #endregion  // Internal

        private void Draw(Graphics gr)
        {
            BackColor = Color.Salmon;
            SetColor(Color.Green);
            gr.DrawLine(Pen, 0, 0, 100, 100);
            SetColor(Color.Blue, 10);
            gr.DrawArc(Pen, 50, 50, 100, 100, 0, 360);
        }
    }
}
