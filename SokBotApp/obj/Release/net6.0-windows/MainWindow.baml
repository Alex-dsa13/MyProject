   M S B A M L   `   `   `  ???? D  @SokBotApp, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SokBotApp	SokBotApp  ;"clr-namespace:SokBotApp.ViewModelsSokBotApp.ViewModels      SokBotApp.MainWindow   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:SokBotApp     9
viewmodels"clr-namespace:SokBotApp.ViewModels       ? Title$  SokApp?? ? WindowStyle$ SingleBorderWindow=? ? 
ResizeMode$ 	CanResize=? ? WindowState$ 	Maximized=? ? Icon$ 	/Icon.png?? ? 	Resources  ?? 
TargetType ?? Property ?? Value??%?   '??       '?? V     ?? " ??.???  ? ??$ 10, 0q???  ? ??$ Normal"???  ? ??$ 20(??? " ??.???  ? ??
 ?   ???  ?@??TextDecorations$ 	Underline{?.??? 	 ? RowDefinitions	 ?? $
??0.1* ??? $??3 ??? $??* ?.+?]? $??0??$??10q?$??False??$??Center=?.+??? .???? 
 ?? TextDecorations$

 None{? ?? Command ?? *ChangePageCommand+ ?? CommandParameter ?? *	StartPage+.?Главная?? .???? $

 None{? ?? *ChangePageCommand1+ ?? *StudentsPage+.?Студенты?? .???? $

 None{? ? Cursor$
 Hand?? ?? *ChangePageCommand+ ?? *
EventsPage+.?Мероприятия?? $??Right=?$??Center=?$??10, 0q??? $?Designed by ?? ?? -   $!??https://vk.com/daniilmalcev??.?.??? $?DaHuKx?? ?? $? and ?? ?? -   $!??https://vk.com/big_koshka13??.?.??? $?
Big_koshka??? $??1??
???   ?? $??2??.+? ?   ? NavigationUIVisibility$ Hidden=????? *CurrentPage+ ?? UpdateSourceTrigger$ PropertyChanged=?