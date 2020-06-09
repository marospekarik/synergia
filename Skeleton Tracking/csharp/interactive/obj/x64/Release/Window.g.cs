﻿#pragma checksum "Window.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "B5A6CDDA27F30304CC2684D1EA5A216A4250D474"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Cubemos.Samples;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Cubemos.Samples {
    
    
    /// <summary>
    /// CaptureWindow
    /// </summary>
    public partial class CaptureWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button refreshDevices;
        
        #line default
        #line hidden
        
        
        #line 39 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton toggleStartStop;
        
        #line default
        #line hidden
        
        
        #line 58 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isEnableTracking;
        
        #line default
        #line hidden
        
        
        #line 62 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isSkeletonOverlay;
        
        #line default
        #line hidden
        
        
        #line 66 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isShow3DCoordinates;
        
        #line default
        #line hidden
        
        
        #line 71 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isOnlySkeletons;
        
        #line default
        #line hidden
        
        
        #line 75 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox isRenderDepthImage;
        
        #line default
        #line hidden
        
        
        #line 88 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock acquisition_status;
        
        #line default
        #line hidden
        
        
        #line 91 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock fps_output;
        
        #line default
        #line hidden
        
        
        #line 94 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock person_count;
        
        #line default
        #line hidden
        
        
        #line 123 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgColor;
        
        #line default
        #line hidden
        
        
        #line 129 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgDepth;
        
        #line default
        #line hidden
        
        
        #line 135 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image usageGuideImage;
        
        #line default
        #line hidden
        
        
        #line 141 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Cnv;
        
        #line default
        #line hidden
        
        
        #line 145 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Cnv2;
        
        #line default
        #line hidden
        
        
        #line 154 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock loadingText;
        
        #line default
        #line hidden
        
        
        #line 164 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button buttonScreenShot;
        
        #line default
        #line hidden
        
        
        #line 173 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton toggleHelp;
        
        #line default
        #line hidden
        
        
        #line 181 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton toggleButtonSettings;
        
        #line default
        #line hidden
        
        
        #line 201 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox logTextBox;
        
        #line default
        #line hidden
        
        
        #line 216 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.TabPanel settingsPanel;
        
        #line default
        #line hidden
        
        
        #line 228 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox camera_source;
        
        #line default
        #line hidden
        
        
        #line 237 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox resolutionOptionBox;
        
        #line default
        #line hidden
        
        
        #line 241 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander rgb_options_expander;
        
        #line default
        #line hidden
        
        
        #line 246 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid rgb_sensor_options;
        
        #line default
        #line hidden
        
        
        #line 249 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox rgbBacklightCompensation;
        
        #line default
        #line hidden
        
        
        #line 256 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider rgbBrightness;
        
        #line default
        #line hidden
        
        
        #line 262 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander depth_sensor_options_expander;
        
        #line default
        #line hidden
        
        
        #line 267 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid depth_sensor_options;
        
        #line default
        #line hidden
        
        
        #line 279 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox presetOptionBox;
        
        #line default
        #line hidden
        
        
        #line 288 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox depthEmitterEnabled;
        
        #line default
        #line hidden
        
        
        #line 299 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider laserPower;
        
        #line default
        #line hidden
        
        
        #line 307 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander post_processing_options_expander;
        
        #line default
        #line hidden
        
        
        #line 313 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid post_processing_options;
        
        #line default
        #line hidden
        
        
        #line 325 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander spatial_filter_expander;
        
        #line default
        #line hidden
        
        
        #line 329 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox spatialFilter;
        
        #line default
        #line hidden
        
        
        #line 332 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid spatial_filter_options;
        
        #line default
        #line hidden
        
        
        #line 346 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slSpatialMagnitude;
        
        #line default
        #line hidden
        
        
        #line 352 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slSpatialSmoothAlpha;
        
        #line default
        #line hidden
        
        
        #line 358 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slSpatialSmoothDelta;
        
        #line default
        #line hidden
        
        
        #line 363 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander temporal_filter_expander;
        
        #line default
        #line hidden
        
        
        #line 367 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox temporalFilter;
        
        #line default
        #line hidden
        
        
        #line 370 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid temporal_filter_options;
        
        #line default
        #line hidden
        
        
        #line 383 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slTemporalSmoothAlpha;
        
        #line default
        #line hidden
        
        
        #line 389 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider slTemporalSmoothDelta;
        
        #line default
        #line hidden
        
        
        #line 403 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox computationBackend;
        
        #line default
        #line hidden
        
        
        #line 409 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlock1;
        
        #line default
        #line hidden
        
        
        #line 412 "Window.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider networkSlider;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/csharp-interactive;component/window.xaml", System.UriKind.Relative);
            
            #line 1 "Window.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "Window.xaml"
            ((Cubemos.Samples.CaptureWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.control_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.refreshDevices = ((System.Windows.Controls.Button)(target));
            
            #line 29 "Window.xaml"
            this.refreshDevices.Click += new System.Windows.RoutedEventHandler(this.ButtonRefreshDevices_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.toggleStartStop = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 48 "Window.xaml"
            this.toggleStartStop.Click += new System.Windows.RoutedEventHandler(this.ToggleStartStop_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.isEnableTracking = ((System.Windows.Controls.CheckBox)(target));
            
            #line 59 "Window.xaml"
            this.isEnableTracking.Checked += new System.Windows.RoutedEventHandler(this.cbEnable_Tracking);
            
            #line default
            #line hidden
            
            #line 60 "Window.xaml"
            this.isEnableTracking.Unchecked += new System.Windows.RoutedEventHandler(this.cbEnable_Tracking);
            
            #line default
            #line hidden
            return;
            case 5:
            this.isSkeletonOverlay = ((System.Windows.Controls.CheckBox)(target));
            
            #line 63 "Window.xaml"
            this.isSkeletonOverlay.Checked += new System.Windows.RoutedEventHandler(this.cbRendering_SkeletonOverlay);
            
            #line default
            #line hidden
            
            #line 64 "Window.xaml"
            this.isSkeletonOverlay.Unchecked += new System.Windows.RoutedEventHandler(this.cbRendering_SkeletonOverlay);
            
            #line default
            #line hidden
            return;
            case 6:
            this.isShow3DCoordinates = ((System.Windows.Controls.CheckBox)(target));
            
            #line 68 "Window.xaml"
            this.isShow3DCoordinates.Checked += new System.Windows.RoutedEventHandler(this.cbRendering_ShowCoordinates);
            
            #line default
            #line hidden
            
            #line 69 "Window.xaml"
            this.isShow3DCoordinates.Unchecked += new System.Windows.RoutedEventHandler(this.cbRendering_ShowCoordinates);
            
            #line default
            #line hidden
            return;
            case 7:
            this.isOnlySkeletons = ((System.Windows.Controls.CheckBox)(target));
            
            #line 72 "Window.xaml"
            this.isOnlySkeletons.Checked += new System.Windows.RoutedEventHandler(this.cbRendering_OnlySkeletons);
            
            #line default
            #line hidden
            
            #line 73 "Window.xaml"
            this.isOnlySkeletons.Unchecked += new System.Windows.RoutedEventHandler(this.cbRendering_OnlySkeletons);
            
            #line default
            #line hidden
            return;
            case 8:
            this.isRenderDepthImage = ((System.Windows.Controls.CheckBox)(target));
            
            #line 76 "Window.xaml"
            this.isRenderDepthImage.Checked += new System.Windows.RoutedEventHandler(this.cbRendering_DepthMapOverlay);
            
            #line default
            #line hidden
            
            #line 77 "Window.xaml"
            this.isRenderDepthImage.Unchecked += new System.Windows.RoutedEventHandler(this.cbRendering_DepthMapOverlay);
            
            #line default
            #line hidden
            return;
            case 9:
            this.acquisition_status = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.fps_output = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.person_count = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.imgColor = ((System.Windows.Controls.Image)(target));
            
            #line 128 "Window.xaml"
            this.imgColor.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.ImgColor_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 13:
            this.imgDepth = ((System.Windows.Controls.Image)(target));
            return;
            case 14:
            this.usageGuideImage = ((System.Windows.Controls.Image)(target));
            return;
            case 15:
            this.Cnv = ((System.Windows.Controls.Canvas)(target));
            return;
            case 16:
            this.Cnv2 = ((System.Windows.Controls.Canvas)(target));
            return;
            case 17:
            this.loadingText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 18:
            this.buttonScreenShot = ((System.Windows.Controls.Button)(target));
            
            #line 170 "Window.xaml"
            this.buttonScreenShot.Click += new System.Windows.RoutedEventHandler(this.ButtonScreenShot_Click);
            
            #line default
            #line hidden
            return;
            case 19:
            this.toggleHelp = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 179 "Window.xaml"
            this.toggleHelp.Click += new System.Windows.RoutedEventHandler(this.ToggleButtonHelp_Click);
            
            #line default
            #line hidden
            return;
            case 20:
            this.toggleButtonSettings = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 187 "Window.xaml"
            this.toggleButtonSettings.Click += new System.Windows.RoutedEventHandler(this.ToggleButtonSettings_Click);
            
            #line default
            #line hidden
            return;
            case 21:
            this.logTextBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 22:
            this.settingsPanel = ((System.Windows.Controls.Primitives.TabPanel)(target));
            return;
            case 23:
            this.camera_source = ((System.Windows.Controls.ComboBox)(target));
            
            #line 229 "Window.xaml"
            this.camera_source.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.Camera_source_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 24:
            this.resolutionOptionBox = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 25:
            this.rgb_options_expander = ((System.Windows.Controls.Expander)(target));
            return;
            case 26:
            this.rgb_sensor_options = ((System.Windows.Controls.Grid)(target));
            return;
            case 27:
            this.rgbBacklightCompensation = ((System.Windows.Controls.CheckBox)(target));
            
            #line 251 "Window.xaml"
            this.rgbBacklightCompensation.Checked += new System.Windows.RoutedEventHandler(this.RgbBacklightCompensation_Checked);
            
            #line default
            #line hidden
            
            #line 252 "Window.xaml"
            this.rgbBacklightCompensation.Unchecked += new System.Windows.RoutedEventHandler(this.RgbBacklightCompensation_Checked);
            
            #line default
            #line hidden
            return;
            case 28:
            this.rgbBrightness = ((System.Windows.Controls.Slider)(target));
            
            #line 258 "Window.xaml"
            this.rgbBrightness.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.RgbBrightness_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 29:
            this.depth_sensor_options_expander = ((System.Windows.Controls.Expander)(target));
            return;
            case 30:
            this.depth_sensor_options = ((System.Windows.Controls.Grid)(target));
            return;
            case 31:
            this.presetOptionBox = ((System.Windows.Controls.ComboBox)(target));
            
            #line 282 "Window.xaml"
            this.presetOptionBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.PresetOptionBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 32:
            this.depthEmitterEnabled = ((System.Windows.Controls.CheckBox)(target));
            
            #line 292 "Window.xaml"
            this.depthEmitterEnabled.Checked += new System.Windows.RoutedEventHandler(this.DepthEmitterEnabled_Checked);
            
            #line default
            #line hidden
            
            #line 293 "Window.xaml"
            this.depthEmitterEnabled.Unchecked += new System.Windows.RoutedEventHandler(this.DepthEmitterEnabled_Checked);
            
            #line default
            #line hidden
            return;
            case 33:
            this.laserPower = ((System.Windows.Controls.Slider)(target));
            
            #line 304 "Window.xaml"
            this.laserPower.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.LaserPower_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 34:
            this.post_processing_options_expander = ((System.Windows.Controls.Expander)(target));
            return;
            case 35:
            this.post_processing_options = ((System.Windows.Controls.Grid)(target));
            return;
            case 36:
            this.spatial_filter_expander = ((System.Windows.Controls.Expander)(target));
            return;
            case 37:
            this.spatialFilter = ((System.Windows.Controls.CheckBox)(target));
            
            #line 329 "Window.xaml"
            this.spatialFilter.Checked += new System.Windows.RoutedEventHandler(this.spatialFilter_Checked);
            
            #line default
            #line hidden
            
            #line 329 "Window.xaml"
            this.spatialFilter.Unchecked += new System.Windows.RoutedEventHandler(this.spatialFilter_Checked);
            
            #line default
            #line hidden
            return;
            case 38:
            this.spatial_filter_options = ((System.Windows.Controls.Grid)(target));
            return;
            case 39:
            this.slSpatialMagnitude = ((System.Windows.Controls.Slider)(target));
            
            #line 346 "Window.xaml"
            this.slSpatialMagnitude.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.spatialFilterMagnitude_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 40:
            this.slSpatialSmoothAlpha = ((System.Windows.Controls.Slider)(target));
            
            #line 352 "Window.xaml"
            this.slSpatialSmoothAlpha.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.spatialFilterSmoothAlpha_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 41:
            this.slSpatialSmoothDelta = ((System.Windows.Controls.Slider)(target));
            
            #line 358 "Window.xaml"
            this.slSpatialSmoothDelta.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.spatialFilterSmoothDelta_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 42:
            this.temporal_filter_expander = ((System.Windows.Controls.Expander)(target));
            return;
            case 43:
            this.temporalFilter = ((System.Windows.Controls.CheckBox)(target));
            
            #line 367 "Window.xaml"
            this.temporalFilter.Checked += new System.Windows.RoutedEventHandler(this.temporalFilter_Checked);
            
            #line default
            #line hidden
            
            #line 367 "Window.xaml"
            this.temporalFilter.Unchecked += new System.Windows.RoutedEventHandler(this.temporalFilter_Checked);
            
            #line default
            #line hidden
            return;
            case 44:
            this.temporal_filter_options = ((System.Windows.Controls.Grid)(target));
            return;
            case 45:
            this.slTemporalSmoothAlpha = ((System.Windows.Controls.Slider)(target));
            
            #line 383 "Window.xaml"
            this.slTemporalSmoothAlpha.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.temporalFilterSmoothAlpha_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 46:
            this.slTemporalSmoothDelta = ((System.Windows.Controls.Slider)(target));
            
            #line 389 "Window.xaml"
            this.slTemporalSmoothDelta.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.temporalFilterSmoothDelta_ValueChanged);
            
            #line default
            #line hidden
            return;
            case 47:
            this.computationBackend = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 48:
            this.textBlock1 = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 49:
            this.networkSlider = ((System.Windows.Controls.Slider)(target));
            
            #line 419 "Window.xaml"
            this.networkSlider.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.NetworkSlider_ValueChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

