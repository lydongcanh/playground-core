terraform {
  cloud {
    organization = "ted-playground"
    workspaces {
      name = "playground-core"
    }
  }
  required_providers {
    neon = {
      source = "kislerdm/neon"
      version = "0.5.0"
    }
    auth0 = {
      source = "auth0/auth0"
      version = "1.6.1"
    }
  }
}

provider "neon" {}

provider "auth0" {}
