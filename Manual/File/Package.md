# ファイルパッケージ

ファイルパッケージングとは、Altseed2で使用するファイルを一つのファイルにまとめる機能を指します。
この機能を使用することで、Altseed2で使用するリソースデータを、ユーザから簡単に見られないようにすることができます。

## パッケージの作り方
パッケージの作成は、[Engine.File.Pack](xref:Altseed2.File.Pack(System.String,System.String))メソッドで、パッケージ化するディレクトリとパッケージのパスを指定することでできます。
また、[Engine.File.PackWithPassword](xref:Altseed2.File.PackWithPassword(System.String,System.String,System.String))メソッドによって、パスワード付きでパッケージ化することが可能です。
パスワード付きのパッケージにすることで、パッケージ化されたリソースデータをユーザから抽出されるのを防ぐことができます。

## パッケージの使い方
[Engine.File.AddRootPackage](xref:Altseed2.File.AddRootPackage(System.String))メソッドでパッケージをルートに指定することが可能で、パッケージ内からファイルを読み込みます。
そして、ルートディレクトリやパッケージは複数指定できます。
ファイルを読み込む時に複数のファイルが見つかった時、後から追加されたルートディレクトリやパッケージから読み込みます。
絶対パスを指定した場合、ルートの指定関係なく絶対パスで指定された先を読み込みます。
パスワード付きのパッケージをルートに指定する場合、[Engine.File.AddRootPackageWithPassword](xref:Altseed2.File.AddRootPackageWithPassword(System.String,System.String))メソッドを使用してください。

> [!TIP]
> 複数のパッケージを読み込んだ時の優先順位を利用することでアップデートパッチを容易に実装できます。
> 例えば、製品の最初でパッケージXに格納されているファイルAがあるとします。ファイルAに不具合が存在することが発覚し、ファイルAを差し替えることになりました。
> このとき、更新した新しいファイルAをパッケージYに格納します。そして、プログラム側ではパッケージX, パッケージYの順に追加するようにしておきます。
> すると同じ名前のファイルAを読み込むときにパッケージXからでなく、後から追加したパッケージYから読み込むようになります。
> このように更新したファイルのみを別のパッケージにまとめることで、 実際に読み込む際のファイルのパス指定を変更することなく容易にファイルの更新を行えます。

> [!NOTE]
> Altseed2のパッケージング機能の内部実装は、Zip圧縮になっています。
> したがって、任意のZipファイルをパッケージとして読み込むことができます。

## サンプル

### パッケージの作成・読み込み

[!code-csharp[Main](../../Src/Samples/File/Package.cs)]

### パスワード付きパッケージの作成・読み込み

[!code-csharp[Main](../../Src/Samples/File/PackageWithPassword.cs)]

### Zipファイルをパッケージとして読み込み

[!code-csharp[Main](../../Src/Samples/File/PackageFromZip.cs)]