   M S B A M L   `   `   `  ????D  @SokBotApp, Version=1.1.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SokBotApp	SokBotApp  5   	   ;"clr-namespace:SokBotApp.ViewModelsSokBotApp.ViewModels  6/       SokBotApp.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SokBotApp     5   	   9
viewmodels"clr-namespace:SokBotApp.ViewModels     6/     ? Title$  SokApp??5   	    ? WindowStyle$ SingleBorderWindow=?6    ? 
ResizeMode$ 	CanResize=?69    ? WindowState$ 	Maximized=?6P    ? Icon$ 	/Icon.png??6h    ? 	Resources 5	       ?? 
TargetType ?? Property ?? Value??%8  '??       '?? ?     ?? 5   
   " ??5      .?5      ??  ? ??$ 10, 0q?6'   ?? 5       ? ??$ Normal"?6+   ?? 5       ? ??$ 20(?6)   5      ?? 5   
   " ??5      .?5      ??  ? ??
 ?   ?6+   ?? 5       ?@??TextDecorations$ 	Underline{?60   5      5      .??5      ? 	 ? RowDefinitions	 5   
   ?? 5      $
??0.1* ?6   ?? 5      $??3 ?6   ?? 5      $??* ?6   .+?5   
   ]? $??0??6   $??10q?5       $??False??5!      $??Center=?5"      .+?5$      ?? .??5%      ?? 
 ?? TextDecorations$

 None{?5'       ?? Command 5%      ?? *ChangePageCommand+ ?? CommandParameter 5&      ?? *	StartPage+.?5'   3   Главная5)      5*      ?? 5,      .??5-      ?? $

 None{?5.   F    5-      ?? *ChangePageCommand1+ 5.      ?? *StudentsPage+.?6]   Студенты50      51      ?? 53      .??54      ?? $

 None{?55   D    ? Cursor$
 Hand??6[    54      ?? *ChangePageCommand+ 55      ?? *
EventsPage+.?6i   Мероприятия57      58      ?? 5A      $??Right=?6   $??Center=?5B      $??10, 0q?5C      ?? 5D      $?Designed by ??6    ?? 5E      -   5        $!??https://vk.com/daniilmalcev??5E   H   .?6r   .?5F      ?? $?DaHuKx??6   5G       ?? 5H      $? and ??6    ?? 5I      -   5        $!??https://vk.com/big_koshka13??5I   H   .?6r   .?5J      ?? $?
Big_koshka??6   5K      5L      5M      ? 5O   
   $??1??6   
???   ?6   ? 5Q   
   $??2??6   .+?5R       ?   ? NavigationUIVisibility$ Hidden=?5T      ??5R      ?? *CurrentPage+ ?? UpdateSourceTrigger$ PropertyChanged=?5T      5U      5V      5W      