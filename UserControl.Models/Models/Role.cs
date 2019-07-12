using System;

namespace UserControl.Models.Models
{
    /// <summary>
    /// Role model.
    /// </summary>
    [Serializable]
    public class Role
    {
        /// <summary>
        /// Unique identifier for current role.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name for current role.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Flag, is the current role checked.
        /// </summary>
        public bool IsChecked { get; set; }
    }
}
