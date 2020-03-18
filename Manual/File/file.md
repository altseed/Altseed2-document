# ファイル

ファイル操作に関する機能を提供します。  
[Engine.File](xref:Altseed.File)では、ファイルを読み込む先のディレクトリ・パッケージの指定やディレクトリのパッケージ化が可能です。
そして、ファイルを読み込むことができ、[StaticFile.Load](xref:Altseed.StaticFile.Load(System.String))メソッドを用いて[StaticFile](xref:Altseed.StaticFile)インスタンスを作成するか、[StreamFile.Load](xref:Altseed.StreamFile.Load(System.String))メソッドを用いて[StreamFile](xref:Altseed.StreamFile)インスタンスを作成する方法の2種類があります。  

## [Engine.File](xref:Altseed.File)

[Engine.File.AddRootDirectory](xref:Altseed.File.AddRootDirectory(System.String))メソッドでファイルを読み込む時のルートを指定します。
一切ルートを指定していないと、カレントディレクトリから相対的にファイルを読み込みます。
ルートディレクトリが指定されていると、ルートディレクトリから相対的にファイルを読み込みます。
また、[Engine.File.AddRootPackage](xref:Altseed.File.AddRootPackage(System.String))メソッドで複数のファイルを1つにまとめたパッケージをルートに指定することが可能で、パッケージ内からファイルを読み込みます。
そして、ルートディレクトリやパッケージは複数指定できます。
ファイルを読み込む時に複数のファイルが見つかった時、後から追加されたルートディレクトリやパッケージから読み込みます。
絶対パスを指定した場合、ルートの指定関係なく絶対パスで指定された先を読み込みます。

> [!TIP]
> 複数のパッケージを読み込んだ時の優先順位を利用することでアップデートパッチを容易に実装できます。
> 例えば、製品の最初でパッケージXに格納されているファイルAがあるとします。ファイルAに不具合が存在することが発覚し、ファイルAを差し替えることになりました。
> このとき、更新した新しいファイルAをパッケージYに格納します。そして、プログラム側ではパッケージX, パッケージYの順に追加するようにしておきます。
> すると同じ名前のファイルAを読み込むときにパッケージXからでなく、後から追加したパッケージYから読み込むようになります。
> このように更新したファイルのみを別のパッケージにまとめることで、 実際に読み込む際のファイルのパス指定を変更することなく容易にファイルの更新を行えます。  

パッケージの作成は、[Engine.File.Pack](xref:Altseed.File.Pack(System.String,System.String))メソッドで、パッケージ化するディレクトリとパッケージのパスを指定することでできます。
また、[Engine.File.PackWithPassword](xref:Altseed.File.PackWithPassword(System.String,System.String,System.String))メソッドによって、パスワード付きでパッケージ化することが可能です。
パスワード付きのパッケージにすることで、パッケージ化されたリソースデータをユーザから抽出されるのを防ぐことができます。
パスワード付きのパッケージをルートに指定する場合、[Engine.File.AddRootPackageWithPassword](Engine.File.AddRootPackageWithPassword(System.String,System.String))メソッドを使用してください。

## [StaticFile](xref:Altseed.StaticFile)

[StaticFile](xref:Altseed.StaticFile)は、ファイルを一括で全て読み込むクラスです。
ファイルを読み込んで[StaticFile](xref:Altseed.StaticFile)インスタンスを生成するには[Load](xref:Altseed.StaticFile.Load(System.String))メソッドを使います。  

読み込んだファイルの内容は、[Buffer](xref:Altseed.StaticFile.Buffer)で、Byte配列として得られます。

> [!TIP]
> 一度、[Load](xref:Altseed.StaticFile.Load(System.String))するとキャッシュされます。
> よって、同じパスでファイルを[Load](xref:Altseed.StaticFile.Load(System.String))した場合、キャッシュから読み込まれるため、読み込み時間が小さくなります。

## [StreamFile](xref:Altseed.StreamFile)

[StreamFile](xref:Altseed.StaticFile)は、ファイルを部分的に読み込むクラスです。
ファイルを読み込んで[StreamFile](xref:Altseed.StreamFile)インスタンスを生成するには[Load](xref:Altseed.StreamFile.Load(System.String))メソッドを使います。  

[Read](xref:Altseed.StreamFile.Read(System.Int32))メソッドによって、指定されたサイズの分だけ、ファイルに格納されているデータを読み込みます。  

読み込んだ内容は、[TempBuffer](xref:Altseed.StreamFile.TempBuffer)で、Byte配列として得られます。
また、現在読み込まれているデータのサイズは、[TempBufferSize](xref:Altseed.StreamFile.TempBufferSize)で得られます。  