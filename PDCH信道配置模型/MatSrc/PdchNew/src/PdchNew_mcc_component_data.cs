//
// MATLAB Compiler: 4.7 (R2007b)
// Date: Wed Sep 28 11:20:48 2011
// Arguments: "-B" "macro_default" "-W" "dotnet:PdchNew,PdchNewclass,0.0,private" "-d"
// "G:\protocolmining\PDCH信道配置模型\MatSrc\PdchNew\src" "-T" "link:lib" "-v"
// "class{PdchNewclass:G:\protocolmining\PDCH信道配置模型\MatSrc\newton.m,G:\protocolminin
// g\PDCH信道配置模型\MatSrc\pdchsim.m}" 
//


using System;

namespace PdchNew
{
  /// <summary>
  /// The MCR Component State
  /// </summary>
  public class MCRComponentState
    {
      /// <summary>
      /// The .NET Builder component name
      /// </summary>
      public static string MCC_PdchNew_name_data= "PdchNew";

      /// <summary>
      /// The component root data
      /// </summary>
      public static string MCC_PdchNew_root_data= "";

      /// <summary>
      /// The public encryption key for the .NET Builder component
      /// </summary>
      public static byte[] MCC_PdchNew_public_data=
                              {(byte)'3', (byte)'0', (byte)'8', (byte)'1',
                               (byte)'9', (byte)'D', (byte)'3', (byte)'0',
                               (byte)'0', (byte)'D', (byte)'0', (byte)'6',
                               (byte)'0', (byte)'9', (byte)'2', (byte)'A',
                               (byte)'8', (byte)'6', (byte)'4', (byte)'8',
                               (byte)'8', (byte)'6', (byte)'F', (byte)'7',
                               (byte)'0', (byte)'D', (byte)'0', (byte)'1',
                               (byte)'0', (byte)'1', (byte)'0', (byte)'1',
                               (byte)'0', (byte)'5', (byte)'0', (byte)'0',
                               (byte)'0', (byte)'3', (byte)'8', (byte)'1',
                               (byte)'8', (byte)'B', (byte)'0', (byte)'0',
                               (byte)'3', (byte)'0', (byte)'8', (byte)'1',
                               (byte)'8', (byte)'7', (byte)'0', (byte)'2',
                               (byte)'8', (byte)'1', (byte)'8', (byte)'1',
                               (byte)'0', (byte)'0', (byte)'C', (byte)'4',
                               (byte)'9', (byte)'C', (byte)'A', (byte)'C',
                               (byte)'3', (byte)'4', (byte)'E', (byte)'D',
                               (byte)'1', (byte)'3', (byte)'A', (byte)'5',
                               (byte)'2', (byte)'0', (byte)'6', (byte)'5',
                               (byte)'8', (byte)'F', (byte)'6', (byte)'F',
                               (byte)'8', (byte)'E', (byte)'0', (byte)'1',
                               (byte)'3', (byte)'8', (byte)'C', (byte)'4',
                               (byte)'3', (byte)'1', (byte)'5', (byte)'B',
                               (byte)'4', (byte)'3', (byte)'1', (byte)'5',
                               (byte)'2', (byte)'7', (byte)'7', (byte)'E',
                               (byte)'D', (byte)'3', (byte)'F', (byte)'7',
                               (byte)'D', (byte)'A', (byte)'E', (byte)'5',
                               (byte)'3', (byte)'0', (byte)'9', (byte)'9',
                               (byte)'D', (byte)'B', (byte)'0', (byte)'8',
                               (byte)'E', (byte)'E', (byte)'5', (byte)'8',
                               (byte)'9', (byte)'F', (byte)'8', (byte)'0',
                               (byte)'4', (byte)'D', (byte)'4', (byte)'B',
                               (byte)'9', (byte)'8', (byte)'1', (byte)'3',
                               (byte)'2', (byte)'6', (byte)'A', (byte)'5',
                               (byte)'2', (byte)'C', (byte)'C', (byte)'E',
                               (byte)'4', (byte)'3', (byte)'8', (byte)'2',
                               (byte)'E', (byte)'9', (byte)'F', (byte)'2',
                               (byte)'B', (byte)'4', (byte)'D', (byte)'0',
                               (byte)'8', (byte)'5', (byte)'E', (byte)'B',
                               (byte)'9', (byte)'5', (byte)'0', (byte)'C',
                               (byte)'7', (byte)'A', (byte)'B', (byte)'1',
                               (byte)'2', (byte)'E', (byte)'D', (byte)'E',
                               (byte)'2', (byte)'D', (byte)'4', (byte)'1',
                               (byte)'2', (byte)'9', (byte)'7', (byte)'8',
                               (byte)'2', (byte)'0', (byte)'E', (byte)'6',
                               (byte)'3', (byte)'7', (byte)'7', (byte)'A',
                               (byte)'5', (byte)'F', (byte)'E', (byte)'B',
                               (byte)'5', (byte)'6', (byte)'8', (byte)'9',
                               (byte)'D', (byte)'4', (byte)'E', (byte)'6',
                               (byte)'0', (byte)'3', (byte)'2', (byte)'F',
                               (byte)'6', (byte)'0', (byte)'C', (byte)'4',
                               (byte)'3', (byte)'0', (byte)'7', (byte)'4',
                               (byte)'A', (byte)'0', (byte)'4', (byte)'C',
                               (byte)'2', (byte)'6', (byte)'A', (byte)'B',
                               (byte)'7', (byte)'2', (byte)'F', (byte)'5',
                               (byte)'4', (byte)'B', (byte)'5', (byte)'1',
                               (byte)'B', (byte)'B', (byte)'4', (byte)'6',
                               (byte)'0', (byte)'5', (byte)'7', (byte)'8',
                               (byte)'7', (byte)'8', (byte)'5', (byte)'B',
                               (byte)'1', (byte)'9', (byte)'9', (byte)'0',
                               (byte)'1', (byte)'4', (byte)'3', (byte)'1',
                               (byte)'4', (byte)'A', (byte)'6', (byte)'5',
                               (byte)'F', (byte)'0', (byte)'9', (byte)'0',
                               (byte)'B', (byte)'6', (byte)'1', (byte)'F',
                               (byte)'C', (byte)'2', (byte)'0', (byte)'1',
                               (byte)'6', (byte)'9', (byte)'4', (byte)'5',
                               (byte)'3', (byte)'B', (byte)'5', (byte)'8',
                               (byte)'F', (byte)'C', (byte)'8', (byte)'B',
                               (byte)'A', (byte)'4', (byte)'3', (byte)'E',
                               (byte)'6', (byte)'7', (byte)'7', (byte)'6',
                               (byte)'E', (byte)'B', (byte)'7', (byte)'E',
                               (byte)'C', (byte)'D', (byte)'3', (byte)'1',
                               (byte)'7', (byte)'8', (byte)'B', (byte)'5',
                               (byte)'6', (byte)'A', (byte)'B', (byte)'0',
                               (byte)'F', (byte)'A', (byte)'0', (byte)'6',
                               (byte)'D', (byte)'D', (byte)'6', (byte)'4',
                               (byte)'9', (byte)'6', (byte)'7', (byte)'C',
                               (byte)'B', (byte)'1', (byte)'4', (byte)'9',
                               (byte)'E', (byte)'5', (byte)'0', (byte)'2',
                               (byte)'0', (byte)'1', (byte)'1', (byte)'1'};

      /// <summary>
      /// The session encryption key for the .NET Builder component
      /// </summary>
      public static byte[] MCC_PdchNew_session_data=
                              {(byte)'6', (byte)'F', (byte)'6', (byte)'8',
                               (byte)'4', (byte)'F', (byte)'3', (byte)'6',
                               (byte)'C', (byte)'A', (byte)'6', (byte)'4',
                               (byte)'5', (byte)'9', (byte)'F', (byte)'8',
                               (byte)'E', (byte)'7', (byte)'5', (byte)'B',
                               (byte)'7', (byte)'A', (byte)'F', (byte)'4',
                               (byte)'C', (byte)'9', (byte)'B', (byte)'0',
                               (byte)'3', (byte)'C', (byte)'3', (byte)'F',
                               (byte)'0', (byte)'4', (byte)'0', (byte)'7',
                               (byte)'C', (byte)'8', (byte)'8', (byte)'2',
                               (byte)'D', (byte)'6', (byte)'0', (byte)'B',
                               (byte)'3', (byte)'B', (byte)'1', (byte)'3',
                               (byte)'9', (byte)'1', (byte)'8', (byte)'B',
                               (byte)'B', (byte)'A', (byte)'F', (byte)'C',
                               (byte)'5', (byte)'C', (byte)'B', (byte)'4',
                               (byte)'1', (byte)'8', (byte)'D', (byte)'6',
                               (byte)'7', (byte)'E', (byte)'F', (byte)'5',
                               (byte)'B', (byte)'6', (byte)'3', (byte)'E',
                               (byte)'8', (byte)'A', (byte)'C', (byte)'F',
                               (byte)'B', (byte)'C', (byte)'5', (byte)'8',
                               (byte)'9', (byte)'A', (byte)'A', (byte)'A',
                               (byte)'E', (byte)'F', (byte)'E', (byte)'D',
                               (byte)'4', (byte)'4', (byte)'D', (byte)'D',
                               (byte)'2', (byte)'1', (byte)'1', (byte)'B',
                               (byte)'8', (byte)'D', (byte)'A', (byte)'F',
                               (byte)'1', (byte)'0', (byte)'B', (byte)'E',
                               (byte)'A', (byte)'B', (byte)'7', (byte)'B',
                               (byte)'7', (byte)'F', (byte)'7', (byte)'D',
                               (byte)'B', (byte)'F', (byte)'4', (byte)'6',
                               (byte)'3', (byte)'1', (byte)'0', (byte)'C',
                               (byte)'5', (byte)'3', (byte)'3', (byte)'D',
                               (byte)'C', (byte)'0', (byte)'5', (byte)'E',
                               (byte)'4', (byte)'1', (byte)'A', (byte)'A',
                               (byte)'2', (byte)'3', (byte)'9', (byte)'8',
                               (byte)'9', (byte)'F', (byte)'2', (byte)'2',
                               (byte)'2', (byte)'9', (byte)'F', (byte)'0',
                               (byte)'4', (byte)'3', (byte)'C', (byte)'C',
                               (byte)'4', (byte)'2', (byte)'E', (byte)'D',
                               (byte)'8', (byte)'A', (byte)'6', (byte)'9',
                               (byte)'8', (byte)'7', (byte)'9', (byte)'1',
                               (byte)'6', (byte)'A', (byte)'8', (byte)'2',
                               (byte)'D', (byte)'2', (byte)'7', (byte)'B',
                               (byte)'A', (byte)'E', (byte)'5', (byte)'0',
                               (byte)'4', (byte)'8', (byte)'4', (byte)'F',
                               (byte)'4', (byte)'1', (byte)'E', (byte)'C',
                               (byte)'1', (byte)'D', (byte)'8', (byte)'2',
                               (byte)'6', (byte)'7', (byte)'5', (byte)'B',
                               (byte)'2', (byte)'9', (byte)'F', (byte)'5',
                               (byte)'7', (byte)'E', (byte)'B', (byte)'3',
                               (byte)'0', (byte)'9', (byte)'B', (byte)'A',
                               (byte)'6', (byte)'5', (byte)'1', (byte)'0',
                               (byte)'A', (byte)'5', (byte)'F', (byte)'1',
                               (byte)'5', (byte)'B', (byte)'D', (byte)'6',
                               (byte)'1', (byte)'B', (byte)'1', (byte)'F',
                               (byte)'6', (byte)'F', (byte)'9', (byte)'1',
                               (byte)'C', (byte)'A', (byte)'3', (byte)'D',
                               (byte)'7', (byte)'F', (byte)'4', (byte)'3',
                               (byte)'F', (byte)'3', (byte)'8', (byte)'7',
                               (byte)'5', (byte)'4', (byte)'5', (byte)'5',
                               (byte)'9', (byte)'E', (byte)'C', (byte)'1',
                               (byte)'D', (byte)'2', (byte)'B', (byte)'F',
                               (byte)'D', (byte)'4', (byte)'A', (byte)'C',
                               (byte)'C', (byte)'7', (byte)'7', (byte)'6',
                               (byte)'B', (byte)'B', (byte)'4', (byte)'C'};

      /// <summary>
      /// The MATLAB path for the .NET Builder component
      /// </summary>
      public static string[] MCC_PdchNew_matlabpath_data= {"PdchNew/",
                                                           "toolbox/compiler/deploy/",
                                                           "$TOOLBOXMATLABDIR/general/",
                                                           "$TOOLBOXMATLABDIR/ops/",
                                                           "$TOOLBOXMATLABDIR/lang/",
                                                           "$TOOLBOXMATLABDIR/elmat/",
                                                           "$TOOLBOXMATLABDIR/elfun/",
                                                           "$TOOLBOXMATLABDIR/specfun/",
                                                           "$TOOLBOXMATLABDIR/matfun/",
                                                           "$TOOLBOXMATLABDIR/datafun/",
                                                           "$TOOLBOXMATLABDIR/polyfun/",
                                                           "$TOOLBOXMATLABDIR/funfun/",
                                                           "$TOOLBOXMATLABDIR/sparfun/",
                                                           "$TOOLBOXMATLABDIR/scribe/",
                                                           "$TOOLBOXMATLABDIR/graph2d/",
                                                           "$TOOLBOXMATLABDIR/graph3d/",
                                                           "$TOOLBOXMATLABDIR/specgraph/",
                                                           "$TOOLBOXMATLABDIR/graphics/",
                                                           "$TOOLBOXMATLABDIR/uitools/",
                                                           "$TOOLBOXMATLABDIR/strfun/",
                                                           "$TOOLBOXMATLABDIR/imagesci/",
                                                           "$TOOLBOXMATLABDIR/iofun/",
                                                           "$TOOLBOXMATLABDIR/audiovideo/",
                                                           "$TOOLBOXMATLABDIR/timefun/",
                                                           "$TOOLBOXMATLABDIR/datatypes/",
                                                           "$TOOLBOXMATLABDIR/verctrl/",
                                                           "$TOOLBOXMATLABDIR/codetools/",
                                                           "$TOOLBOXMATLABDIR/helptools/",
                                                           "$TOOLBOXMATLABDIR/winfun/",
                                                           "$TOOLBOXMATLABDIR/demos/",
                                                           "$TOOLBOXMATLABDIR/timeseries/",
                                                           "$TOOLBOXMATLABDIR/hds/",
                                                           "$TOOLBOXMATLABDIR/guide/",
                                                           "$TOOLBOXMATLABDIR/plottools/",
                                                           "toolbox/local/"};
      /// <summary>
      /// The MATLAB path count
      /// </summary>
      public static int MCC_PdchNew_matlabpath_data_count= 35;

      /// <summary>
      /// The class path for the .NET Builder component
      /// </summary>
      public static string[] MCC_PdchNew_classpath_data= {"\0"};

      /// <summary>
      /// The class path count
      /// </summary>
      public static int MCC_PdchNew_classpath_data_count= 0;

      /// <summary>
      /// The lib path for the .NET Builder component
      /// </summary>
      public static string[] MCC_PdchNew_libpath_data= {"\0"};

      /// <summary>
      /// The lib path count
      /// </summary>
      public static int MCC_PdchNew_libpath_data_count= 0;

      /// <summary>
      /// The MCR application options
      /// </summary>
      public static string[] MCC_PdchNew_mcr_application_options= {"\0"};

      /// <summary>
      /// The MCR application options count
      /// </summary>
      public static int MCC_PdchNew_mcr_application_option_count= 0;

      /// <summary>
      /// The MCR runtime options
      /// </summary>
      public static string[] MCC_PdchNew_mcr_runtime_options= {"\0"};

      /// <summary>
      /// The MCR runtime options count
      /// </summary>
      public static int MCC_PdchNew_mcr_runtime_option_count= 0;

      /// <summary>
      /// The component preferences directory
      /// </summary>
      public static string MCC_PdchNew_mcr_pref_dir= "PdchNew_B554CF12C724281DB40F44A9AFB4FD12";

      /// <summary>
      /// Runtime warning states
      /// </summary>
      public static string[] MCC_PdchNew_set_warning_state= {"off:MATLAB:dispatcher:nameConflict"};
      /// <summary>
      /// Runtime warning state count
      /// </summary>
      public static int MCC_PdchNew_set_warning_state_count= 0;
    }
}
