# repro-process-wkhtml-net-5

Reproduces issue with starting wkhtmltopdf via ``ProcessStartInfo``:

1. On linux machine (Ubuntu 20.04.1 LTS for me)
2. Install wkhtmltopdf. For example (or see https://gist.github.com/brunogaspar/bd89079245923c04be6b0f92af431c10#gistcomment-3481489):
    - sudo apt install wget xfonts-75dpi
    - wget https://github.com/wkhtmltopdf/packaging/releases/download/0.12.6-1/wkhtmltox_0.12.6-1.bionic_amd64.deb
    - sudo dpkg -i wkhtmltox_0.12.6-1.bionic_amd64.deb
3. Solution with NET 5.0 throws, the 3.1 one works:
    > System.Exception: QPainter::begin(): Returned false
   Exit with code 1, due to unknown error.
