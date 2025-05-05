using Schedule.Model.Entities;
using Schedule.Model.Services;

namespace Schedule.View;

public partial class CadastraClientePage : ContentPage
{
    private readonly IClienteService _clienteService;
    private readonly Action<Cliente> onClienteCadastrado;
    public CadastraClientePage(IClienteService clienteService, Action<Cliente> callback)
	{
		InitializeComponent();
        _clienteService = clienteService;
        onClienteCadastrado = callback;
    }

    private void btnFoto_Clicked(object sender, EventArgs e)
    {

    }

    private async void btnCadastrar_Clicked(object sender, EventArgs e)
    {
        var cliente = new Cliente();
        cliente.Nome = NomeEntry.Text;

        await _clienteService.CreateAsync(cliente);

        await DisplayAlert("Sucesso", "Cliente cadastrado com sucesso!", "OK");

        var clientes = await _clienteService.GetAllAsync();

        onClienteCadastrado?.Invoke(cliente);
        await Navigation.PopAsync();
    }

}