# ファイル

ファイル操作に関する機能を提供します。  
[Engine.File](xref:Altseed2.File)では、ファイルを読み込む先のディレクトリ・パッケージの指定やディレクトリのパッケージ化が可能です。
そして、ファイルを読み込むことができ、[StaticFile.Create](xref:Altseed2.StaticFile.Create(System.String))メソッドを用いて[StaticFile](xref:Altseed2.StaticFile)インスタンスを作成するか、[StreamFile.Create](xref:Altseed2.StreamFile.Create(System.String))メソッドを用いて[StreamFile](xref:Altseed2.StreamFile)インスタンスを作成する方法の2種類があります。  

## [Engine.File](xref:Altseed2.File)

[Engine.File.AddRootDirectory](xref:Altseed2.File.AddRootDirectory(System.String))メソッドでファイルを読み込む時のルートを指定します。
一切ルートを指定していないと、カレントディレクトリから相対的にファイルを読み込みます。
ルートディレクトリが指定されていると、ルートディレクトリから相対的にファイルを読み込みます。
また、[Engine.File.AddRootPackage](xref:Altseed2.File.AddRootPackage(System.String))メソッドで複数のファイルを1つにまとめたパッケージをルートに指定することが可能で、パッケージ内からファイルを読み込みます。
そして、ルートディレクトリやパッケージは複数指定できます。
ファイルを読み込む時に複数のファイルが見つかった時、後から追加されたルートディレクトリやパッケージから読み込みます。
絶対パスを指定した場合、ルートの指定関係なく絶対パスで指定された先を読み込みます。

> [!TIP]
> 複数のパッケージを読み込んだ時の優先順位を利用することでアップデートパッチを容易に実装できます。
> 例えば、製品の最初でパッケージXに格納されているファイルAがあるとします。ファイルAに不具合が存在することが発覚し、ファイルAを差し替えることになりました。
> このとき、更新した新しいファイルAをパッケージYに格納します。そして、プログラム側ではパッケージX, パッケージYの順に追加するようにしておきます。
> すると同じ名前のファイルAを読み込むときにパッケージXからでなく、後から追加したパッケージYから読み込むようになります。
> このように更新したファイルのみを別のパッケージにまとめることで、 実際に読み込む際のファイルのパス指定を変更することなく容易にファイルの更新を行えます。  

パッケージの作成は、[Engine.File.Pack](xref:Altseed2.File.Pack(System.String,System.String))メソッドで、パッケージ化するディレクトリとパッケージのパスを指定することでできます。
また、[Engine.File.PackWithPassword](xref:Altseed2.File.PackWithPassword(System.String,System.String,System.String))メソッドによって、パスワード付きでパッケージ化することが可能です。
パスワード付きのパッケージにすることで、パッケージ化されたリソースデータをユーザから抽出されるのを防ぐことができます。
パスワード付きのパッケージをルートに指定する場合、[Engine.File.AddRootPackageWithPassword](xref:Altseed2.File.AddRootPackageWithPassword(System.String,System.String))メソッドを使用してください。

> [!NOTE]
> パッケージング機能の内部実装はZIP圧縮になっています。
> したがって、任意のZIPファイルをパッケージファイルとして読み込むことができます。

## [StaticFile](xref:Altseed2.StaticFile)

[StaticFile](xref:Altseed2.StaticFile)は、ファイルを一括で全て読み込むクラスです。
ファイルを読み込んで[StaticFile](xref:Altseed2.StaticFile)インスタンスを生成するには[Create](xref:Altseed2.StaticFile.Create(System.String))メソッドを使います。  

読み込んだファイルの内容は、[Buffer](xref:Altseed2.StaticFile.Buffer)で、Byte配列として得られます。

> [!TIP]
> 一度、[Create](xref:Altseed2.StaticFile.Create(System.String))するとキャッシュされます。
> よって、同じパスでファイルを[Create](xref:Altseed2.StaticFile.Create(System.String))した場合、キャッシュから読み込まれるため、読み込み時間が小さくなります。

## [StreamFile](xref:Altseed2.StreamFile)

[StreamFile](xref:Altseed2.StaticFile)は、ファイルを部分的に読み込むクラスです。
ファイルを読み込んで[StreamFile](xref:Altseed2.StreamFile)インスタンスを生成するには[Create](xref:Altseed2.StreamFile.Create(System.String))メソッドを使います。  

[Read](xref:Altseed2.StreamFile.Read(System.Int32))メソッドによって、指定されたサイズの分だけ、ファイルに格納されているデータを読み込みます。  

読み込んだ内容は、[TempBuffer](xref:Altseed2.StreamFile.TempBuffer)で、Byte配列として得られます。
また、現在読み込まれているデータのサイズは、[TempBufferSize](xref:Altseed2.StreamFile.TempBufferSize)で得られます。  

## サンプル

### StaticFileによるファイル読み込み

[!code-csharp[Main](../../Src/Samples/File/StaticFile.cs)]

### StreamFileによるファイル読み込み

[!code-csharp[Main](../../Src/Samples/File/StreamFile.cs)]

### パッケージファイルの作成・読み込み

[!code-csharp[Main](../../Src/Samples/File/Package.cs)]

### パスワード付きのパッケージファイルの作成・読み込み

[!code-csharp[Main](../../Src/Samples/File/PackageWithPasssword.cs)]

### ZIPファイルをパッケージファイルとして読み込み

[!code-csharp[Main](../../Src/Samples/File/PackageFromZip.cs)]
