using SvTools.Services;

const string fileName = "config.json";
var fileService = new FileService();
var config = new ConfigService(
    new LanguageService(fileService, new HttpService(new HttpClient()), fileName),
    new SettingsService(fileService, fileName));
