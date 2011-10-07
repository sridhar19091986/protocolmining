/*
* MATLAB Compiler: 4.7 (R2007b)
* Date: Wed Sep 28 11:20:48 2011
* Arguments: "-B" "macro_default" "-W" "dotnet:PdchNew,PdchNewclass,0.0,private" "-d"
* "G:\protocolmining\PDCH信道配置模型\MatSrc\PdchNew\src" "-T" "link:lib" "-v"
* "class{PdchNewclass:G:\protocolmining\PDCH信道配置模型\MatSrc\newton.m,G:\protocolmining
* \PDCH信道配置模型\MatSrc\pdchsim.m}" 
*/

using System;
using System.Reflection;

using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;


[assembly: System.Reflection.AssemblyVersion("0.0.*")]
#if SHARED
[assembly: System.Reflection.AssemblyKeyFile(@"")]
#endif

namespace PdchNew
{
  /// <summary>
  /// The PdchNewclass class provides a CLS compliant interface to the M-functions
  /// contained in the files:
  /// <newpara></newpara>
  /// G:\protocolmining\PDCH信道配置模型\MatSrc\newton.m
  /// <newpara></newpara>
  /// G:\protocolmining\PDCH信道配置模型\MatSrc\pdchsim.m
  /// <newpara></newpara>
  /// deployprint.m
  /// <newpara></newpara>
  /// printdlg.m
  /// </summary>
  /// <remarks>
  /// @Version 0.0
  /// </remarks>
  public class PdchNewclass : IDisposable
    {
      #region Constructors

      /// <summary internal= "true">
      /// The static constructor instantiates and initializes the MATLAB Component
      /// Runtime instance.
      /// </summary>
      static PdchNewclass()
        {
          if (MWArray.MCRAppInitialized)
            {
              Assembly assembly= Assembly.GetExecutingAssembly();

              string ctfFilePath= assembly.Location;

              int lastDelimeter= ctfFilePath.LastIndexOf(@"\");

              ctfFilePath= ctfFilePath.Remove(lastDelimeter, (ctfFilePath.Length - lastDelimeter));

              mcr= new MWMCR(MCRComponentState.MCC_PdchNew_name_data,
                             MCRComponentState.MCC_PdchNew_root_data,
                             MCRComponentState.MCC_PdchNew_public_data,
                             MCRComponentState.MCC_PdchNew_session_data,
                             MCRComponentState.MCC_PdchNew_matlabpath_data,
                             MCRComponentState.MCC_PdchNew_classpath_data,
                             MCRComponentState.MCC_PdchNew_libpath_data,
                             MCRComponentState.MCC_PdchNew_mcr_application_options,
                             MCRComponentState.MCC_PdchNew_mcr_runtime_options,
                             MCRComponentState.MCC_PdchNew_mcr_pref_dir,
                             MCRComponentState.MCC_PdchNew_set_warning_state,
                             ctfFilePath, true);
            }
          else
            {
              throw new ApplicationException("MWArray assembly could not be initialized");
            }
        }


      /// <summary>
      /// Constructs a new instance of the PdchNewclass class.
      /// </summary>
      public PdchNewclass()
        {
        }


      #endregion Constructors

      #region Finalize

      /// <summary internal= "true">
      /// Class destructor called by the CLR garbage collector.
      /// </summary>
      ~PdchNewclass()
        {
          Dispose(false);
        }


      /// <summary>
      /// Frees the native resources associated with this object
      /// </summary>
      public void Dispose()
        {
          Dispose(true);

          GC.SuppressFinalize(this);
        }


      /// <summary internal= "true">
      /// Internal dispose function
      /// </summary>
      protected virtual void Dispose(bool disposing)
        {
          if (!disposed)
            {
              disposed= true;

              if (disposing)
                {
                  // Free managed resources;
                }

              // Free native resources
            }
        }


      #endregion Finalize

      #region Methods

      /// <summary>
      /// Provides a single output, 0-input interface to the newton M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// [x, y] = newton(A,b,x0,niter);
      /// solves the linear least squares problem with nonnegative variables using the
      /// newton's algorithm in [1].
      /// Input:
      /// A:      [MxN] matrix 
      /// b:      [Mx1] vector
      /// x0:     [Nx1] vector of initial values. x0 > 0. Default value: ones(n,1)
      /// niter:  Number of iterations. Default value: 10
      /// Output
      /// x:      solution
      /// y:      complementary solution
      /// [1] Portugal, Judice and Vicente, A comparison of block pivoting and
      /// interior point algorithms for linear least squares problems with
      /// nonnegative variables, Mathematics of Computation, 63(1994), pp. 625-643
      /// Uriel Roque
      /// 02.05.2006
      /// </remarks>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray newton()
        {
          return mcr.EvaluateFunction("newton");
        }


      /// <summary>
      /// Provides a single output, 1-input interface to the newton M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// [x, y] = newton(A,b,x0,niter);
      /// solves the linear least squares problem with nonnegative variables using the
      /// newton's algorithm in [1].
      /// Input:
      /// A:      [MxN] matrix 
      /// b:      [Mx1] vector
      /// x0:     [Nx1] vector of initial values. x0 > 0. Default value: ones(n,1)
      /// niter:  Number of iterations. Default value: 10
      /// Output
      /// x:      solution
      /// y:      complementary solution
      /// [1] Portugal, Judice and Vicente, A comparison of block pivoting and
      /// interior point algorithms for linear least squares problems with
      /// nonnegative variables, Mathematics of Computation, 63(1994), pp. 625-643
      /// Uriel Roque
      /// 02.05.2006
      /// </remarks>
      /// <param name="A">Input argument #1</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray newton(MWArray A)
        {
          return mcr.EvaluateFunction("newton", A);
        }


      /// <summary>
      /// Provides a single output, 2-input interface to the newton M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// [x, y] = newton(A,b,x0,niter);
      /// solves the linear least squares problem with nonnegative variables using the
      /// newton's algorithm in [1].
      /// Input:
      /// A:      [MxN] matrix 
      /// b:      [Mx1] vector
      /// x0:     [Nx1] vector of initial values. x0 > 0. Default value: ones(n,1)
      /// niter:  Number of iterations. Default value: 10
      /// Output
      /// x:      solution
      /// y:      complementary solution
      /// [1] Portugal, Judice and Vicente, A comparison of block pivoting and
      /// interior point algorithms for linear least squares problems with
      /// nonnegative variables, Mathematics of Computation, 63(1994), pp. 625-643
      /// Uriel Roque
      /// 02.05.2006
      /// </remarks>
      /// <param name="A">Input argument #1</param>
      /// <param name="b">Input argument #2</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray newton(MWArray A, MWArray b)
        {
          return mcr.EvaluateFunction("newton", A, b);
        }


      /// <summary>
      /// Provides a single output, 3-input interface to the newton M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// [x, y] = newton(A,b,x0,niter);
      /// solves the linear least squares problem with nonnegative variables using the
      /// newton's algorithm in [1].
      /// Input:
      /// A:      [MxN] matrix 
      /// b:      [Mx1] vector
      /// x0:     [Nx1] vector of initial values. x0 > 0. Default value: ones(n,1)
      /// niter:  Number of iterations. Default value: 10
      /// Output
      /// x:      solution
      /// y:      complementary solution
      /// [1] Portugal, Judice and Vicente, A comparison of block pivoting and
      /// interior point algorithms for linear least squares problems with
      /// nonnegative variables, Mathematics of Computation, 63(1994), pp. 625-643
      /// Uriel Roque
      /// 02.05.2006
      /// </remarks>
      /// <param name="A">Input argument #1</param>
      /// <param name="b">Input argument #2</param>
      /// <param name="x0">Input argument #3</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray newton(MWArray A, MWArray b, MWArray x0)
        {
          return mcr.EvaluateFunction("newton", A, b, x0);
        }


      /// <summary>
      /// Provides a single output, 4-input interface to the newton M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// [x, y] = newton(A,b,x0,niter);
      /// solves the linear least squares problem with nonnegative variables using the
      /// newton's algorithm in [1].
      /// Input:
      /// A:      [MxN] matrix 
      /// b:      [Mx1] vector
      /// x0:     [Nx1] vector of initial values. x0 > 0. Default value: ones(n,1)
      /// niter:  Number of iterations. Default value: 10
      /// Output
      /// x:      solution
      /// y:      complementary solution
      /// [1] Portugal, Judice and Vicente, A comparison of block pivoting and
      /// interior point algorithms for linear least squares problems with
      /// nonnegative variables, Mathematics of Computation, 63(1994), pp. 625-643
      /// Uriel Roque
      /// 02.05.2006
      /// </remarks>
      /// <param name="A">Input argument #1</param>
      /// <param name="b">Input argument #2</param>
      /// <param name="x0">Input argument #3</param>
      /// <param name="niter">Input argument #4</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray newton(MWArray A, MWArray b, MWArray x0, MWArray niter)
        {
          return mcr.EvaluateFunction("newton", A, b, x0, niter);
        }


      /// <summary>
      /// Provides the standard 0-input interface to the newton M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// [x, y] = newton(A,b,x0,niter);
      /// solves the linear least squares problem with nonnegative variables using the
      /// newton's algorithm in [1].
      /// Input:
      /// A:      [MxN] matrix 
      /// b:      [Mx1] vector
      /// x0:     [Nx1] vector of initial values. x0 > 0. Default value: ones(n,1)
      /// niter:  Number of iterations. Default value: 10
      /// Output
      /// x:      solution
      /// y:      complementary solution
      /// [1] Portugal, Judice and Vicente, A comparison of block pivoting and
      /// interior point algorithms for linear least squares problems with
      /// nonnegative variables, Mathematics of Computation, 63(1994), pp. 625-643
      /// Uriel Roque
      /// 02.05.2006
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] newton(int numArgsOut)
        {
          return mcr.EvaluateFunction(numArgsOut, "newton");
        }


      /// <summary>
      /// Provides the standard 1-input interface to the newton M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// [x, y] = newton(A,b,x0,niter);
      /// solves the linear least squares problem with nonnegative variables using the
      /// newton's algorithm in [1].
      /// Input:
      /// A:      [MxN] matrix 
      /// b:      [Mx1] vector
      /// x0:     [Nx1] vector of initial values. x0 > 0. Default value: ones(n,1)
      /// niter:  Number of iterations. Default value: 10
      /// Output
      /// x:      solution
      /// y:      complementary solution
      /// [1] Portugal, Judice and Vicente, A comparison of block pivoting and
      /// interior point algorithms for linear least squares problems with
      /// nonnegative variables, Mathematics of Computation, 63(1994), pp. 625-643
      /// Uriel Roque
      /// 02.05.2006
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="A">Input argument #1</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] newton(int numArgsOut, MWArray A)
        {
          return mcr.EvaluateFunction(numArgsOut, "newton", A);
        }


      /// <summary>
      /// Provides the standard 2-input interface to the newton M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// [x, y] = newton(A,b,x0,niter);
      /// solves the linear least squares problem with nonnegative variables using the
      /// newton's algorithm in [1].
      /// Input:
      /// A:      [MxN] matrix 
      /// b:      [Mx1] vector
      /// x0:     [Nx1] vector of initial values. x0 > 0. Default value: ones(n,1)
      /// niter:  Number of iterations. Default value: 10
      /// Output
      /// x:      solution
      /// y:      complementary solution
      /// [1] Portugal, Judice and Vicente, A comparison of block pivoting and
      /// interior point algorithms for linear least squares problems with
      /// nonnegative variables, Mathematics of Computation, 63(1994), pp. 625-643
      /// Uriel Roque
      /// 02.05.2006
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="A">Input argument #1</param>
      /// <param name="b">Input argument #2</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] newton(int numArgsOut, MWArray A, MWArray b)
        {
          return mcr.EvaluateFunction(numArgsOut, "newton", A, b);
        }


      /// <summary>
      /// Provides the standard 3-input interface to the newton M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// [x, y] = newton(A,b,x0,niter);
      /// solves the linear least squares problem with nonnegative variables using the
      /// newton's algorithm in [1].
      /// Input:
      /// A:      [MxN] matrix 
      /// b:      [Mx1] vector
      /// x0:     [Nx1] vector of initial values. x0 > 0. Default value: ones(n,1)
      /// niter:  Number of iterations. Default value: 10
      /// Output
      /// x:      solution
      /// y:      complementary solution
      /// [1] Portugal, Judice and Vicente, A comparison of block pivoting and
      /// interior point algorithms for linear least squares problems with
      /// nonnegative variables, Mathematics of Computation, 63(1994), pp. 625-643
      /// Uriel Roque
      /// 02.05.2006
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="A">Input argument #1</param>
      /// <param name="b">Input argument #2</param>
      /// <param name="x0">Input argument #3</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] newton(int numArgsOut, MWArray A, MWArray b, MWArray x0)
        {
          return mcr.EvaluateFunction(numArgsOut, "newton", A, b, x0);
        }


      /// <summary>
      /// Provides the standard 4-input interface to the newton M-function.
      /// </summary>
      /// <remarks>
      /// M-Documentation:
      /// [x, y] = newton(A,b,x0,niter);
      /// solves the linear least squares problem with nonnegative variables using the
      /// newton's algorithm in [1].
      /// Input:
      /// A:      [MxN] matrix 
      /// b:      [Mx1] vector
      /// x0:     [Nx1] vector of initial values. x0 > 0. Default value: ones(n,1)
      /// niter:  Number of iterations. Default value: 10
      /// Output
      /// x:      solution
      /// y:      complementary solution
      /// [1] Portugal, Judice and Vicente, A comparison of block pivoting and
      /// interior point algorithms for linear least squares problems with
      /// nonnegative variables, Mathematics of Computation, 63(1994), pp. 625-643
      /// Uriel Roque
      /// 02.05.2006
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="A">Input argument #1</param>
      /// <param name="b">Input argument #2</param>
      /// <param name="x0">Input argument #3</param>
      /// <param name="niter">Input argument #4</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] newton(int numArgsOut, MWArray A, MWArray b,
                              MWArray x0, MWArray niter)
        {
          return mcr.EvaluateFunction(numArgsOut, "newton", A, b, x0, niter);
        }


      /// <summary>
      /// Provides an interface for the newton function in which the input and output
      /// arguments are specified as an array of MWArrays.
      /// </summary>
      /// <remarks>
      /// This method will allocate and return by reference the output argument
      /// array.<newpara></newpara>
      /// M-Documentation:
      /// [x, y] = newton(A,b,x0,niter);
      /// solves the linear least squares problem with nonnegative variables using the
      /// newton's algorithm in [1].
      /// Input:
      /// A:      [MxN] matrix 
      /// b:      [Mx1] vector
      /// x0:     [Nx1] vector of initial values. x0 > 0. Default value: ones(n,1)
      /// niter:  Number of iterations. Default value: 10
      /// Output
      /// x:      solution
      /// y:      complementary solution
      /// [1] Portugal, Judice and Vicente, A comparison of block pivoting and
      /// interior point algorithms for linear least squares problems with
      /// nonnegative variables, Mathematics of Computation, 63(1994), pp. 625-643
      /// Uriel Roque
      /// 02.05.2006
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return</param>
      /// <param name= "argsOut">Array of MWArray output arguments</param>
      /// <param name= "argsIn">Array of MWArray input arguments</param>
      ///
      public void newton(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
        {
          mcr.EvaluateFunction("newton", numArgsOut, ref argsOut, argsIn);
        }


      /// <summary>
      /// Provides a single output, 0-input interface to the pdchsim M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray pdchsim()
        {
          return mcr.EvaluateFunction("pdchsim");
        }


      /// <summary>
      /// Provides a single output, 1-input interface to the pdchsim M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="traffic">Input argument #1</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray pdchsim(MWArray traffic)
        {
          return mcr.EvaluateFunction("pdchsim", traffic);
        }


      /// <summary>
      /// Provides a single output, 2-input interface to the pdchsim M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="traffic">Input argument #1</param>
      /// <param name="pdchuse">Input argument #2</param>
      /// <returns>An MWArray containing the first output argument.</returns>
      ///
      public MWArray pdchsim(MWArray traffic, MWArray pdchuse)
        {
          return mcr.EvaluateFunction("pdchsim", traffic, pdchuse);
        }


      /// <summary>
      /// Provides the standard 0-input interface to the pdchsim M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] pdchsim(int numArgsOut)
        {
          return mcr.EvaluateFunction(numArgsOut, "pdchsim");
        }


      /// <summary>
      /// Provides the standard 1-input interface to the pdchsim M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="traffic">Input argument #1</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] pdchsim(int numArgsOut, MWArray traffic)
        {
          return mcr.EvaluateFunction(numArgsOut, "pdchsim", traffic);
        }


      /// <summary>
      /// Provides the standard 2-input interface to the pdchsim M-function.
      /// </summary>
      /// <remarks>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return.</param>
      /// <param name="traffic">Input argument #1</param>
      /// <param name="pdchuse">Input argument #2</param>
      /// <returns>An Array of length "numArgsOut" containing the output
      /// arguments.</returns>
      ///
      public MWArray[] pdchsim(int numArgsOut, MWArray traffic, MWArray pdchuse)
        {
          return mcr.EvaluateFunction(numArgsOut, "pdchsim", traffic, pdchuse);
        }


      /// <summary>
      /// Provides an interface for the pdchsim function in which the input and output
      /// arguments are specified as an array of MWArrays.
      /// </summary>
      /// <remarks>
      /// This method will allocate and return by reference the output argument
      /// array.<newpara></newpara>
      /// </remarks>
      /// <param name="numArgsOut">The number of output arguments to return</param>
      /// <param name= "argsOut">Array of MWArray output arguments</param>
      /// <param name= "argsIn">Array of MWArray input arguments</param>
      ///
      public void pdchsim(int numArgsOut, ref MWArray[] argsOut, MWArray[] argsIn)
        {
          mcr.EvaluateFunction("pdchsim", numArgsOut, ref argsOut, argsIn);
        }


      /// <summary>
      /// This method will cause a MATLAB figure window to behave as a modal dialog box.
      /// The method will not return until all the figure windows associated with this
      /// component have been closed.
      /// </summary>
      /// <remarks>
      /// An application should only call this method when required to keep the
      /// MATLAB figure window from disappearing.  Other techniques, such as calling
      /// Console.ReadLine() from the application should be considered where
      /// possible.</remarks>
      ///
      public void WaitForFiguresToDie()
        {
          mcr.WaitForFiguresToDie();
        }


      
      #endregion Methods

      #region Class Members

      private static MWMCR mcr= null;

      private bool disposed= false;

      #endregion Class Members
    }
}
