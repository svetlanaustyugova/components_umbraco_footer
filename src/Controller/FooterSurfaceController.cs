using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using Zone.UmbracoMapper;

namespace Graph.Components.Navigation
{
	public class FooterSurfaceController : SurfaceController
	{
		private readonly IUmbracoMapper _mapper;

		public FooterSurfaceController(IUmbracoMapper mapper)
		{
			_mapper = mapper;
		}

		public ActionResult Index()
		{
			var settings = new UmbracoHelper(UmbracoContext.Current)
				.TypedContent(FooterConfig.SettingsNodeId);

			var footerModel = new FooterModel();
			_mapper.Map(settings, footerModel);

			return View("/App_Plugins/Footer/Views/Footer.cshtml", footerModel);
		}
	}
}
