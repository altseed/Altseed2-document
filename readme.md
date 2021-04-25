# Altseed2 Document

[Altseed2](https://github.com/altseed/altseed2-csharp)のドキュメント

## Issue
issueは[Altseed2/issues](https://github.com/altseed/Altseed2/issues)に作成してください。

## ウェブサイトへの反映
master ブランチへ push されると自動的に [altseed/altseed.github.io](https://github.com/altseed/altseed.github.io) へのCommitが作成されて、最新の内容が反映されます。


# 生成に必要なもの

- Visual Studio
  - ほかのC#コンパイラでいけるかは不明
  - Homebrew で入れた Mono はダメとある。
- [DocFX](https://github.com/dotnet/docfx)
  - `choco install docfx` するか Release からバイナリを落として解凍し、パスを通す
  - バージョンは 2.56.1
- Python3
  - PyYaml

# 生成

1. `Pull.bat` を実行しサブモジュールを更新する
1. `Build.bat を実行しリファレンスと各ページを生成する

# ローカルでの閲覧

- 生成された `Src` フォルダ以下を直接ブラウザで見るのは CORS policy に引っかかって TOC など一部の機能が動作しないため非推奨
- `docfx --serve` を実行すると リファレンスとページが生成されたのち、HTTPサーバが起動してブラウザから localhost:8080 で見られるようになる。ただし`docfx --serve` を実行している端末からしか閲覧できない。
- `docfx metadata` と `docfx build` を実行したのち、`Web Server for Chrome` などを使って別のHTTPサーバを立てて見るという方法もある。

# ReferenceExtract.yml について

内部向けクラスなど、ユーザに向けて公開しない要素は適切にフィルタを書いておかないと、すべて出力されてしまう。
エンジンの更新のたびに公開することを意図していないものが混入していないかを検出するため、出力したメンバーの
一覧を保存しておく。

# 書き方

- 基本的には Markdown。シンタックスについては[ココ](https://github.github.com/gfm/)を参照
- 一部 DocFX 独自拡張があるのでそれについては[ココ](https://dotnet.github.io/docfx/spec/docfx_flavored_markdown.html?tabs=tabid-1%2Ctabid-a)
  - ソースコード埋め込みとNOTEくらいか

## 構造について
```
- index.md ・・・ トップページ
- References　・・・ リファレンス（自動生成なので触らない）
- Manual
  - *.md ・・・ 各機能に関する文書（書く）
  - *.cs ・・・ ~~各機能に埋め込むサンプルコード（書く）~~ サンプルコードは EngineのSamplesフォルダ以下に置く
  - *.png ・・・ 埋め込む画像（撮るか描く）
  - toc.yml ・・・ サンプルの目次（書く）
- Tutorials
  - *.md ・・・ チュートリアルに関する文書（書く）
  - ~~*.cs ・・・ チュートリアルに埋め込むサンプルコード（書く）~~
  - *.png ・・・ チュートリアルに埋め込む画像（撮るか描く）
  - toc.yml ・・・ チュートリアルの目次（書く）
- Site ・・・ 出力先
```

- toc.yml は新しいファイルを生成したら手動で追記する必要あり（目次に載せないなら書かない）
- SamplesとTutorials以下に置いたpng画像はコピーされる
