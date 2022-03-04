namespace notes___WinFormsDependencyInjection
{
    public partial class Form1 : Form
    {
        private readonly ILogger _logger;
        public Form1(ILogger logger)
        {
            _logger = logger;
            InitializeComponent();
        }
    }
}