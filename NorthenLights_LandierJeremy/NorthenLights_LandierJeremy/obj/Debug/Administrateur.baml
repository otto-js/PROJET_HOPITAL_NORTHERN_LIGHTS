   M S B A M L   `   `   `  ����V  RNorthenLights_LandierJeremy, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:NorthenLights_LandierJeremyNorthenLights_LandierJeremy  5      0    *NorthenLights_LandierJeremy.Administrateur   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      ;local)clr-namespace:NorthenLights_LandierJeremy     5      -   5          � Title$  ADMIN��5	       � SizeToContent$ WidthAndHeight=�5
       � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5      .��5      � $	��393��5   	   .+�5   
   �� $��ADMINISTRER MEDECIN��5      $��
214,29,0,0q�5         	TitleText#��[  5      o� 5   
   $
��Left=�5      $��18��5      $	��Top=�5      $	��399��5      .@�5      m� -   5        $��Consulter Patients��5      5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataMedecin��5      $
��Left=�5      $	��157��5       $��5,85,0,0q�5!      $	��Top=�5"      $	��389��5#      ���	#FF92E6D7$ �� IsSynchronizedWithCurrentItem$
 TrueY�5%         AutoGenerateColumns .  ��5'      ��    Columns 5)      0  *System.Windows.Controls.DataGridTextColumn  5*      ,  &System.Windows.Controls.DataGridColumn   Header$ 
IDMédecin��5+      1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 5,      �� *	IDMedecin+  5-      
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 5.      $ Prénom��5/      	 50      �� *prenom+  51      $
 * 52      $	 Nom��53      	 54      �� *nom+56      �� 57   
   $
��Left=�58      $	��143��59      $	��Top=�5:      $	��389��5;      $��	5,245,0,0q�5<      .@�5=      �� -   5         ��Name$ 
tabAjouter��5>      $��AJOUTER��5?      $	��125��5@      $��	-2,-2,2,0q�5A      .��5B      � .+�5C      �� $	��NOM��5D      $
��Left=�5E      $��33,5,0,0q�5F      $	��Top=�5G      $	��120��5H      �� 5I      -   5         ��Name$ 	txtboxNom��5J      $��25��5K      $��	33,26,0,0q�5L       �� TextWrapping$
 Wrap=�5M      $	��150��5N      5O      �� 5P      $��PRENOM��5Q      $
��Left=�5R      $��	33,54,0,0q�5S      $	��Top=�5T      $	��120��5U      �� 5V      -   5        $ txtboxPrenom��5W      $��	33,75,0,0q�5X      5Y      �� 5Z      -   5        $��AJOUTER��5[      $
��Left=�5\      $��
260,43,0,0q�5]      $	��Top=�5^      $��98��5_      $��38��5a      5b      5c      �� 5d      $��MODIFIER��5e      $	��125��5f      $��	2,-2,-2,0q�5g      .��5h      � .+�5j      �� $	��NOM��5k      $
��Left=�5l      $��33,5,0,0q�5m      $	��Top=�5n      $	��120��5o      �� 5p      -   5        $ txtboxModifieNom��5q      $��	33,26,0,0q�5r      5s      �� 5t      $��PRENOM��5u      $
��Left=�5v      $��	33,54,0,0q�5w      $	��Top=�5x      $	��120��5y      �� 5z      -	   5        $ txtboxModifiePrenom��5{      $��	33,74,0,0q�5|      5}      �� 5~      -
   5        $��MODIFIER��5      $
��Left=�5�      $��
260,43,0,0q�5�      $	��Top=�5�      $��98��5�      $��38��5�      5�      5�      �� 5�      $��	SUPPRIMER��5�      $	��125��5�      $��	6,-2,-6,0q�5�      .��5�      � .+�5�      �� $	��NOM��5�      $
��Left=�5�      $��33,5,0,0q�5�      $	��Top=�5�      $	��120��5�      �� 5�      -   5        $ txtboxSupprimeNom��5�      $��	33,26,0,0q�5�      {�.  5�      �� 5�      $��PRENOM��5�      $
��Left=�5�      $��	33,54,0,0q�5�      $	��Top=�5�      $	��120��5�      �� 5�      -   5        $ txtboxSupprimePrenom��5�      $��	33,74,0,0q�5�      {�.  5�      �� 5�      -   5        $��	SUPPRIMER��5�      $
��Left=�5�      $��
260,43,0,0q�5�      $	��Top=�5�      $��98��5�      $��38��5�      5�      5�      5�      5�      �� 5�   
   ���	#FFAEFFFB$
��Left=�5�      $��54��5�      $��	26,26,0,0q�5�      $	��Top=�5�      $��24��5�      �� 5�   
   $��N L H��5�      $
��Left=�5�      $��	11,41,0,0q�5�      $	��Top=�5�      $��55��5�      $
��Bold"�5�      
�������$��Center=�5�      ���	#FFA5FBFF$��24��5�      5�      5�      