using Schedule.Model.Entities;
using Schedule.Model.Helper;
using Schedule.Model.Repositories;
using Schedule.Model.Services;

namespace Schedule.View;

public partial class HomePage : ContentPage
{
    private CadastraHorario? CadastraHorarioPage
    {
        get
        {
            return App.Current?.Handler?.MauiContext?.Services.GetService<CadastraHorario>();
        }
    }
    private readonly IClienteService _clienteService;
    private readonly IScheduleService _scheduleService;
    private List<Cliente> _clientes;
    private List<ScheduleData> _schedules;
    public HomePage(IClienteService clienteService, IScheduleService scheduleService)
    {
        InitializeComponent();
        _clientes = new List<Cliente>();
        _clientes = new List<Cliente>();
        _clienteService = clienteService;
        _scheduleService = scheduleService;
        CarregarClientes();
        CarregarSchedules();
    }

    private async void AddButton_Clicked(object sender, EventArgs e)
    {
        var page = CriarCadastraHorarioPage();
        await Navigation.PushAsync(page);
    }

    private async void ClienteButton_Clicked(object sender, EventArgs e)
    {
        var page = CriarCadastroClientePage();
        await Navigation.PushAsync(page);
    }

    private async void OnConcluirSwipe(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipeItem && swipeItem.BindingContext is ScheduleData schedule)
        {
            schedule.Status = 1; // Concluído
            await _scheduleService.UpdateAsync(schedule);
            CarregarSchedules();
        }
    }

    private async void OnCancelarSwipe(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipeItem && swipeItem.BindingContext is ScheduleData schedule)
        {
            schedule.Status = 2; // Cancelado
            await _scheduleService.UpdateAsync(schedule);
            CarregarSchedules();
        }
    }

    private async Task LoadSchedulesAsync()
    {
        SchedulesCollectionView.ItemsSource = _schedules;
    }


    private CadastraClientePage CriarCadastroClientePage()
    {
        var clienteService = _clienteService;

        return new CadastraClientePage(clienteService, (cliente) =>
        {
            CarregarClientes();
        });
    }

    private CadastraHorario CriarCadastraHorarioPage()
    {
        var scheduleService = _scheduleService;
        return new CadastraHorario(_clientes, scheduleService, (schedule) =>
        {
            CarregarSchedules();
        });
    }

    private async void CarregarClientes()
    {
        try
        {
            var clientes = await _clienteService.GetAllAsync();
            _clientes = clientes.ToList();

        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Erro ao carregar clientes: {ex.Message}", "OK");
        }
    }

    private async void CarregarSchedules()
    {
        try
        {
            var allSchedules = await _scheduleService.GetAllAsync();

            _schedules = allSchedules
                .Where(s => s.Status == 0)
                .OrderBy(s => s.DataAtendimento)
                .ThenBy(s => s.HoraAtendimento)
                .ToList();

            await LoadSchedulesAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Erro ao carregar schedules: {ex.Message}", "OK");
        }
    }

}
