    using System.ComponentModel;
    using Exiled.API.Interfaces;

    public class Config : IConfig
    {
        /// <inheritdoc/>
        [Description("Whether the plugin is enabled.")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;
}