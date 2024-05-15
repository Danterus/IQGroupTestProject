using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorApp1
{
    public class EntityFormBase : ComponentBase
    {
        [Inject]
        public EntityService EntityService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public MyEntity Entity { get; set; } = new MyEntity();
        public string ErrorMessage { get; set; }
        public string DoneMessage { get; set; }

        public async Task HandleValidSubmit()
        {
            try
            {
                if (string.IsNullOrEmpty(Entity.Id))
                {
                    await EntityService.InsertEntityAsync(Entity);
                    DoneMessage = $"Entity {Entity.Name} added successfuly";
                }
                else
                {
                    await EntityService.UpdateEntityAsync(Entity.Id, Entity);
                    DoneMessage = $"Entity for {Entity.Name} updated successfuly";
                }
                //NavigationManager.NavigateTo("/entity-form");
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Error: {ex.Message}";
            }
        }
    }
}
