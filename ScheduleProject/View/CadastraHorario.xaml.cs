using Schedule.Model.Entities;
using Schedule.Model.Services;

namespace Schedule.View;

public partial class CadastraHorario : ContentPage
{
    
    private readonly List<Cliente> clientesList;
    private readonly IScheduleService _scheduleService;
    private readonly Action<ScheduleData> onHoriarioCadastrado;

    public CadastraHorario(IEnumerable<Cliente> clientes, IScheduleService scheduleService, Action<ScheduleData> callback)
    {
        InitializeComponent();
        clientesList = clientes.ToList();
        clientePicker.ItemsSource = clientesList;
        _scheduleService = scheduleService;
        onHoriarioCadastrado = callback;
    }

    private void btnSalvar_Clicked(object sender, EventArgs e)
    {
        try
        {
            var schedule = new ScheduleData
            {
                Cliente = clientePicker.SelectedItem as Cliente,
                DataAtendimento = dataPicker.Date,
                HoraAtendimento = horarioPicker.Time
            };

            string text = valorEntry.Text?.Replace("R$", "").Trim();
            double valorConvert = double.TryParse(text, out var result) ? result : 0;

            schedule.Valor = valorConvert;
            _scheduleService.CreateAsync(schedule);

            DisplayAlert("Sucesso", "Horário cadastrado com sucesso!", "OK");
            onHoriarioCadastrado?.Invoke(schedule);
            Navigation.PopAsync();

        }
        catch (Exception ex)
        {
            DisplayAlert("Erro", ex.Message, "OK");
        }
    }
}