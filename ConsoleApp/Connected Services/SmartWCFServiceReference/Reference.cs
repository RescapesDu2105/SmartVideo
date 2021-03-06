﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleApp.SmartWCFServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SmartWCFServiceReference.ISmartWCFService")]
    public interface ISmartWCFService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetData", ReplyAction="http://tempuri.org/ISmartWCFService/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetData", ReplyAction="http://tempuri.org/ISmartWCFService/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetFilmById", ReplyAction="http://tempuri.org/ISmartWCFService/GetFilmByIdResponse")]
        DTOLib.FilmDTO GetFilmById(int idFilm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetFilmById", ReplyAction="http://tempuri.org/ISmartWCFService/GetFilmByIdResponse")]
        System.Threading.Tasks.Task<DTOLib.FilmDTO> GetFilmByIdAsync(int idFilm);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetActorByIdActor", ReplyAction="http://tempuri.org/ISmartWCFService/GetActorByIdActorResponse")]
        DTOLib.ActorDTO GetActorByIdActor(int idActor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetActorByIdActor", ReplyAction="http://tempuri.org/ISmartWCFService/GetActorByIdActorResponse")]
        System.Threading.Tasks.Task<DTOLib.ActorDTO> GetActorByIdActorAsync(int idActor);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetFilmByName", ReplyAction="http://tempuri.org/ISmartWCFService/GetFilmByNameResponse")]
        DTOLib.FilmDTO GetFilmByName(string filmName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetFilmByName", ReplyAction="http://tempuri.org/ISmartWCFService/GetFilmByNameResponse")]
        System.Threading.Tasks.Task<DTOLib.FilmDTO> GetFilmByNameAsync(string filmName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetFilms", ReplyAction="http://tempuri.org/ISmartWCFService/GetFilmsResponse")]
        DTOLib.FilmDTO[] GetFilms(string table, string critere, int page);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetFilms", ReplyAction="http://tempuri.org/ISmartWCFService/GetFilmsResponse")]
        System.Threading.Tasks.Task<DTOLib.FilmDTO[]> GetFilmsAsync(string table, string critere, int page);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetNumberOfFilms", ReplyAction="http://tempuri.org/ISmartWCFService/GetNumberOfFilmsResponse")]
        DTOLib.FilmDTO[] GetNumberOfFilms();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetNumberOfFilms", ReplyAction="http://tempuri.org/ISmartWCFService/GetNumberOfFilmsResponse")]
        System.Threading.Tasks.Task<DTOLib.FilmDTO[]> GetNumberOfFilmsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetFilmInfos", ReplyAction="http://tempuri.org/ISmartWCFService/GetFilmInfosResponse")]
        DTOLib.FilmDTO GetFilmInfos(DTOLib.FilmDTO Film);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetFilmInfos", ReplyAction="http://tempuri.org/ISmartWCFService/GetFilmInfosResponse")]
        System.Threading.Tasks.Task<DTOLib.FilmDTO> GetFilmInfosAsync(DTOLib.FilmDTO Film);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetFilmsPage", ReplyAction="http://tempuri.org/ISmartWCFService/GetFilmsPageResponse")]
        DTOLib.FilmDTO[] GetFilmsPage(int page);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetFilmsPage", ReplyAction="http://tempuri.org/ISmartWCFService/GetFilmsPageResponse")]
        System.Threading.Tasks.Task<DTOLib.FilmDTO[]> GetFilmsPageAsync(int page);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetActors", ReplyAction="http://tempuri.org/ISmartWCFService/GetActorsResponse")]
        DTOLib.ActorDTO[] GetActors();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetActors", ReplyAction="http://tempuri.org/ISmartWCFService/GetActorsResponse")]
        System.Threading.Tasks.Task<DTOLib.ActorDTO[]> GetActorsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/IsActorExists", ReplyAction="http://tempuri.org/ISmartWCFService/IsActorExistsResponse")]
        DTOLib.ActorDTO IsActorExists(string actorName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/IsActorExists", ReplyAction="http://tempuri.org/ISmartWCFService/IsActorExistsResponse")]
        System.Threading.Tasks.Task<DTOLib.ActorDTO> IsActorExistsAsync(string actorName);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetGenres", ReplyAction="http://tempuri.org/ISmartWCFService/GetGenresResponse")]
        DTOLib.GenreDTO[] GetGenres();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetGenres", ReplyAction="http://tempuri.org/ISmartWCFService/GetGenresResponse")]
        System.Threading.Tasks.Task<DTOLib.GenreDTO[]> GetGenresAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetDirectors", ReplyAction="http://tempuri.org/ISmartWCFService/GetDirectorsResponse")]
        DTOLib.DirectorDTO[] GetDirectors();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetDirectors", ReplyAction="http://tempuri.org/ISmartWCFService/GetDirectorsResponse")]
        System.Threading.Tasks.Task<DTOLib.DirectorDTO[]> GetDirectorsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/UpdateTrailerFilm", ReplyAction="http://tempuri.org/ISmartWCFService/UpdateTrailerFilmResponse")]
        void UpdateTrailerFilm(int idFilm, string url);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/UpdateTrailerFilm", ReplyAction="http://tempuri.org/ISmartWCFService/UpdateTrailerFilmResponse")]
        System.Threading.Tasks.Task UpdateTrailerFilmAsync(int idFilm, string url);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/CountFilms", ReplyAction="http://tempuri.org/ISmartWCFService/CountFilmsResponse")]
        int CountFilms();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/CountFilms", ReplyAction="http://tempuri.org/ISmartWCFService/CountFilmsResponse")]
        System.Threading.Tasks.Task<int> CountFilmsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/CountFilmsRecherche", ReplyAction="http://tempuri.org/ISmartWCFService/CountFilmsRechercheResponse")]
        int CountFilmsRecherche(string table, string critere);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/CountFilmsRecherche", ReplyAction="http://tempuri.org/ISmartWCFService/CountFilmsRechercheResponse")]
        System.Threading.Tasks.Task<int> CountFilmsRechercheAsync(string table, string critere);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetClientById", ReplyAction="http://tempuri.org/ISmartWCFService/GetClientByIdResponse")]
        DTOLib.ClientDTO GetClientById(string idClient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetClientById", ReplyAction="http://tempuri.org/ISmartWCFService/GetClientByIdResponse")]
        System.Threading.Tasks.Task<DTOLib.ClientDTO> GetClientByIdAsync(string idClient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetHitsById", ReplyAction="http://tempuri.org/ISmartWCFService/GetHitsByIdResponse")]
        DTOLib.HitsDTO GetHitsById(int idHits);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetHitsById", ReplyAction="http://tempuri.org/ISmartWCFService/GetHitsByIdResponse")]
        System.Threading.Tasks.Task<DTOLib.HitsDTO> GetHitsByIdAsync(int idHits);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetLocationById", ReplyAction="http://tempuri.org/ISmartWCFService/GetLocationByIdResponse")]
        DTOLib.LocationDTO GetLocationById(int idLocation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetLocationById", ReplyAction="http://tempuri.org/ISmartWCFService/GetLocationByIdResponse")]
        System.Threading.Tasks.Task<DTOLib.LocationDTO> GetLocationByIdAsync(int idLocation);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetLocationsClient", ReplyAction="http://tempuri.org/ISmartWCFService/GetLocationsClientResponse")]
        DTOLib.LocationDTO[] GetLocationsClient(string idClient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetLocationsClient", ReplyAction="http://tempuri.org/ISmartWCFService/GetLocationsClientResponse")]
        System.Threading.Tasks.Task<DTOLib.LocationDTO[]> GetLocationsClientAsync(string idClient);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/AddLocationClient", ReplyAction="http://tempuri.org/ISmartWCFService/AddLocationClientResponse")]
        void AddLocationClient(string idClient, int idFilm, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/AddLocationClient", ReplyAction="http://tempuri.org/ISmartWCFService/AddLocationClientResponse")]
        System.Threading.Tasks.Task AddLocationClientAsync(string idClient, int idFilm, System.DateTime date);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetClients", ReplyAction="http://tempuri.org/ISmartWCFService/GetClientsResponse")]
        DTOLib.ClientDTO[] GetClients();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetClients", ReplyAction="http://tempuri.org/ISmartWCFService/GetClientsResponse")]
        System.Threading.Tasks.Task<DTOLib.ClientDTO[]> GetClientsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetHits", ReplyAction="http://tempuri.org/ISmartWCFService/GetHitsResponse")]
        DTOLib.HitsDTO[] GetHits();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetHits", ReplyAction="http://tempuri.org/ISmartWCFService/GetHitsResponse")]
        System.Threading.Tasks.Task<DTOLib.HitsDTO[]> GetHitsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetLocations", ReplyAction="http://tempuri.org/ISmartWCFService/GetLocationsResponse")]
        DTOLib.LocationDTO[] GetLocations();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetLocations", ReplyAction="http://tempuri.org/ISmartWCFService/GetLocationsResponse")]
        System.Threading.Tasks.Task<DTOLib.LocationDTO[]> GetLocationsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/AddHits", ReplyAction="http://tempuri.org/ISmartWCFService/AddHitsResponse")]
        void AddHits(string IdClient, int IdCritere, System.DateTime date, string Type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/AddHits", ReplyAction="http://tempuri.org/ISmartWCFService/AddHitsResponse")]
        System.Threading.Tasks.Task AddHitsAsync(string IdClient, int IdCritere, System.DateTime date, string Type);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetHitsFilms", ReplyAction="http://tempuri.org/ISmartWCFService/GetHitsFilmsResponse")]
        DTOLib.HitsDTO[] GetHitsFilms();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetHitsFilms", ReplyAction="http://tempuri.org/ISmartWCFService/GetHitsFilmsResponse")]
        System.Threading.Tasks.Task<DTOLib.HitsDTO[]> GetHitsFilmsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetHitsActeurs", ReplyAction="http://tempuri.org/ISmartWCFService/GetHitsActeursResponse")]
        DTOLib.HitsDTO[] GetHitsActeurs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetHitsActeurs", ReplyAction="http://tempuri.org/ISmartWCFService/GetHitsActeursResponse")]
        System.Threading.Tasks.Task<DTOLib.HitsDTO[]> GetHitsActeursAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/AddStatistiques", ReplyAction="http://tempuri.org/ISmartWCFService/AddStatistiquesResponse")]
        void AddStatistiques(System.Collections.Generic.Dictionary<int, int> Top3Films, System.Collections.Generic.Dictionary<int, int> Top3Acteurs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/AddStatistiques", ReplyAction="http://tempuri.org/ISmartWCFService/AddStatistiquesResponse")]
        System.Threading.Tasks.Task AddStatistiquesAsync(System.Collections.Generic.Dictionary<int, int> Top3Films, System.Collections.Generic.Dictionary<int, int> Top3Acteurs);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetStatistiquesFilms", ReplyAction="http://tempuri.org/ISmartWCFService/GetStatistiquesFilmsResponse")]
        DTOLib.StatistiquesDTO[] GetStatistiquesFilms();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetStatistiquesFilms", ReplyAction="http://tempuri.org/ISmartWCFService/GetStatistiquesFilmsResponse")]
        System.Threading.Tasks.Task<DTOLib.StatistiquesDTO[]> GetStatistiquesFilmsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetStatistiquesActeurs", ReplyAction="http://tempuri.org/ISmartWCFService/GetStatistiquesActeursResponse")]
        DTOLib.StatistiquesDTO[] GetStatistiquesActeurs();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISmartWCFService/GetStatistiquesActeurs", ReplyAction="http://tempuri.org/ISmartWCFService/GetStatistiquesActeursResponse")]
        System.Threading.Tasks.Task<DTOLib.StatistiquesDTO[]> GetStatistiquesActeursAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISmartWCFServiceChannel : ConsoleApp.SmartWCFServiceReference.ISmartWCFService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SmartWCFServiceClient : System.ServiceModel.ClientBase<ConsoleApp.SmartWCFServiceReference.ISmartWCFService>, ConsoleApp.SmartWCFServiceReference.ISmartWCFService {
        
        public SmartWCFServiceClient() {
        }
        
        public SmartWCFServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SmartWCFServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SmartWCFServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SmartWCFServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public DTOLib.FilmDTO GetFilmById(int idFilm) {
            return base.Channel.GetFilmById(idFilm);
        }
        
        public System.Threading.Tasks.Task<DTOLib.FilmDTO> GetFilmByIdAsync(int idFilm) {
            return base.Channel.GetFilmByIdAsync(idFilm);
        }
        
        public DTOLib.ActorDTO GetActorByIdActor(int idActor) {
            return base.Channel.GetActorByIdActor(idActor);
        }
        
        public System.Threading.Tasks.Task<DTOLib.ActorDTO> GetActorByIdActorAsync(int idActor) {
            return base.Channel.GetActorByIdActorAsync(idActor);
        }
        
        public DTOLib.FilmDTO GetFilmByName(string filmName) {
            return base.Channel.GetFilmByName(filmName);
        }
        
        public System.Threading.Tasks.Task<DTOLib.FilmDTO> GetFilmByNameAsync(string filmName) {
            return base.Channel.GetFilmByNameAsync(filmName);
        }
        
        public DTOLib.FilmDTO[] GetFilms(string table, string critere, int page) {
            return base.Channel.GetFilms(table, critere, page);
        }
        
        public System.Threading.Tasks.Task<DTOLib.FilmDTO[]> GetFilmsAsync(string table, string critere, int page) {
            return base.Channel.GetFilmsAsync(table, critere, page);
        }
        
        public DTOLib.FilmDTO[] GetNumberOfFilms() {
            return base.Channel.GetNumberOfFilms();
        }
        
        public System.Threading.Tasks.Task<DTOLib.FilmDTO[]> GetNumberOfFilmsAsync() {
            return base.Channel.GetNumberOfFilmsAsync();
        }
        
        public DTOLib.FilmDTO GetFilmInfos(DTOLib.FilmDTO Film) {
            return base.Channel.GetFilmInfos(Film);
        }
        
        public System.Threading.Tasks.Task<DTOLib.FilmDTO> GetFilmInfosAsync(DTOLib.FilmDTO Film) {
            return base.Channel.GetFilmInfosAsync(Film);
        }
        
        public DTOLib.FilmDTO[] GetFilmsPage(int page) {
            return base.Channel.GetFilmsPage(page);
        }
        
        public System.Threading.Tasks.Task<DTOLib.FilmDTO[]> GetFilmsPageAsync(int page) {
            return base.Channel.GetFilmsPageAsync(page);
        }
        
        public DTOLib.ActorDTO[] GetActors() {
            return base.Channel.GetActors();
        }
        
        public System.Threading.Tasks.Task<DTOLib.ActorDTO[]> GetActorsAsync() {
            return base.Channel.GetActorsAsync();
        }
        
        public DTOLib.ActorDTO IsActorExists(string actorName) {
            return base.Channel.IsActorExists(actorName);
        }
        
        public System.Threading.Tasks.Task<DTOLib.ActorDTO> IsActorExistsAsync(string actorName) {
            return base.Channel.IsActorExistsAsync(actorName);
        }
        
        public DTOLib.GenreDTO[] GetGenres() {
            return base.Channel.GetGenres();
        }
        
        public System.Threading.Tasks.Task<DTOLib.GenreDTO[]> GetGenresAsync() {
            return base.Channel.GetGenresAsync();
        }
        
        public DTOLib.DirectorDTO[] GetDirectors() {
            return base.Channel.GetDirectors();
        }
        
        public System.Threading.Tasks.Task<DTOLib.DirectorDTO[]> GetDirectorsAsync() {
            return base.Channel.GetDirectorsAsync();
        }
        
        public void UpdateTrailerFilm(int idFilm, string url) {
            base.Channel.UpdateTrailerFilm(idFilm, url);
        }
        
        public System.Threading.Tasks.Task UpdateTrailerFilmAsync(int idFilm, string url) {
            return base.Channel.UpdateTrailerFilmAsync(idFilm, url);
        }
        
        public int CountFilms() {
            return base.Channel.CountFilms();
        }
        
        public System.Threading.Tasks.Task<int> CountFilmsAsync() {
            return base.Channel.CountFilmsAsync();
        }
        
        public int CountFilmsRecherche(string table, string critere) {
            return base.Channel.CountFilmsRecherche(table, critere);
        }
        
        public System.Threading.Tasks.Task<int> CountFilmsRechercheAsync(string table, string critere) {
            return base.Channel.CountFilmsRechercheAsync(table, critere);
        }
        
        public DTOLib.ClientDTO GetClientById(string idClient) {
            return base.Channel.GetClientById(idClient);
        }
        
        public System.Threading.Tasks.Task<DTOLib.ClientDTO> GetClientByIdAsync(string idClient) {
            return base.Channel.GetClientByIdAsync(idClient);
        }
        
        public DTOLib.HitsDTO GetHitsById(int idHits) {
            return base.Channel.GetHitsById(idHits);
        }
        
        public System.Threading.Tasks.Task<DTOLib.HitsDTO> GetHitsByIdAsync(int idHits) {
            return base.Channel.GetHitsByIdAsync(idHits);
        }
        
        public DTOLib.LocationDTO GetLocationById(int idLocation) {
            return base.Channel.GetLocationById(idLocation);
        }
        
        public System.Threading.Tasks.Task<DTOLib.LocationDTO> GetLocationByIdAsync(int idLocation) {
            return base.Channel.GetLocationByIdAsync(idLocation);
        }
        
        public DTOLib.LocationDTO[] GetLocationsClient(string idClient) {
            return base.Channel.GetLocationsClient(idClient);
        }
        
        public System.Threading.Tasks.Task<DTOLib.LocationDTO[]> GetLocationsClientAsync(string idClient) {
            return base.Channel.GetLocationsClientAsync(idClient);
        }
        
        public void AddLocationClient(string idClient, int idFilm, System.DateTime date) {
            base.Channel.AddLocationClient(idClient, idFilm, date);
        }
        
        public System.Threading.Tasks.Task AddLocationClientAsync(string idClient, int idFilm, System.DateTime date) {
            return base.Channel.AddLocationClientAsync(idClient, idFilm, date);
        }
        
        public DTOLib.ClientDTO[] GetClients() {
            return base.Channel.GetClients();
        }
        
        public System.Threading.Tasks.Task<DTOLib.ClientDTO[]> GetClientsAsync() {
            return base.Channel.GetClientsAsync();
        }
        
        public DTOLib.HitsDTO[] GetHits() {
            return base.Channel.GetHits();
        }
        
        public System.Threading.Tasks.Task<DTOLib.HitsDTO[]> GetHitsAsync() {
            return base.Channel.GetHitsAsync();
        }
        
        public DTOLib.LocationDTO[] GetLocations() {
            return base.Channel.GetLocations();
        }
        
        public System.Threading.Tasks.Task<DTOLib.LocationDTO[]> GetLocationsAsync() {
            return base.Channel.GetLocationsAsync();
        }
        
        public void AddHits(string IdClient, int IdCritere, System.DateTime date, string Type) {
            base.Channel.AddHits(IdClient, IdCritere, date, Type);
        }
        
        public System.Threading.Tasks.Task AddHitsAsync(string IdClient, int IdCritere, System.DateTime date, string Type) {
            return base.Channel.AddHitsAsync(IdClient, IdCritere, date, Type);
        }
        
        public DTOLib.HitsDTO[] GetHitsFilms() {
            return base.Channel.GetHitsFilms();
        }
        
        public System.Threading.Tasks.Task<DTOLib.HitsDTO[]> GetHitsFilmsAsync() {
            return base.Channel.GetHitsFilmsAsync();
        }
        
        public DTOLib.HitsDTO[] GetHitsActeurs() {
            return base.Channel.GetHitsActeurs();
        }
        
        public System.Threading.Tasks.Task<DTOLib.HitsDTO[]> GetHitsActeursAsync() {
            return base.Channel.GetHitsActeursAsync();
        }
        
        public void AddStatistiques(System.Collections.Generic.Dictionary<int, int> Top3Films, System.Collections.Generic.Dictionary<int, int> Top3Acteurs) {
            base.Channel.AddStatistiques(Top3Films, Top3Acteurs);
        }
        
        public System.Threading.Tasks.Task AddStatistiquesAsync(System.Collections.Generic.Dictionary<int, int> Top3Films, System.Collections.Generic.Dictionary<int, int> Top3Acteurs) {
            return base.Channel.AddStatistiquesAsync(Top3Films, Top3Acteurs);
        }
        
        public DTOLib.StatistiquesDTO[] GetStatistiquesFilms() {
            return base.Channel.GetStatistiquesFilms();
        }
        
        public System.Threading.Tasks.Task<DTOLib.StatistiquesDTO[]> GetStatistiquesFilmsAsync() {
            return base.Channel.GetStatistiquesFilmsAsync();
        }
        
        public DTOLib.StatistiquesDTO[] GetStatistiquesActeurs() {
            return base.Channel.GetStatistiquesActeurs();
        }
        
        public System.Threading.Tasks.Task<DTOLib.StatistiquesDTO[]> GetStatistiquesActeursAsync() {
            return base.Channel.GetStatistiquesActeursAsync();
        }
    }
}
