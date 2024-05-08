using Basedatos.Modelo;

namespace Basedatos.Views;

public partial class vPersona : ContentPage
{
    private Persona personaSeleccionada;

    public vPersona()
    {
        InitializeComponent();
    }

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        App.personRepo.AddNewPerson(txtName.Text);
        txtName.Text = "";
    }

    private void btnObtener_Clicked(object sender, EventArgs e)
    {
        lblStatus.Text = "";
        List<Persona> people = App.personRepo.GetAllPeople();
        listaPersona.ItemsSource = people;
    }

    private void listaPersona_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        personaSeleccionada = (Persona)e.CurrentSelection.FirstOrDefault();
        if (personaSeleccionada != null)
        {
            
            txtEditName.Text = personaSeleccionada.Name; 
            btnActualizarDato.IsEnabled = true;
            btnEliminarDato.IsEnabled = true;
        }
        else
        {
            txtName.Text = string.Empty;
            txtEditName.Text = string.Empty; // Limpiar el txtEditName cuando no hay selección
            btnActualizarDato.IsEnabled = false;
            btnEliminarDato.IsEnabled = false;
        }
    }


    private void btnActualizarDato_Clicked(object sender, EventArgs e)
    {
        if (personaSeleccionada != null)
        {
            personaSeleccionada.Name = txtEditName.Text; // Utilizar el valor del txtEditName
            App.personRepo.UpdatePerson(personaSeleccionada);
            btnActualizarDato.IsEnabled = false;
            btnEliminarDato.IsEnabled = false;
            btnObtener_Clicked(sender, e);
        }
    }

    private void btnEliminarDato_Clicked(object sender, EventArgs e)
    {
        if (personaSeleccionada != null)
        {
            App.personRepo.DeletePerson(personaSeleccionada.Id);
            btnActualizarDato.IsEnabled = false;
            btnEliminarDato.IsEnabled = false;
            btnObtener_Clicked(sender, e);
        }
    }



}