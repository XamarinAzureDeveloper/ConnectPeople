using System.Collections.Generic;

namespace UXDivers.Artina.Grial
{
	public class DashboardViewModel : ViewModel
	{
		public List<SampleCategory> Items { 
			get 
			{ 
				return SamplesDefinition.SamplesCategoryList;
			} 
		}
	}
}